using LoginProyectMVC.Data;
using LoginProyectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace LoginProyectMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // ==== VISTA DE LOGIN ====
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.UserName == model.Username);
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    // Crear claims para la autenticación
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString())  // Guardar el ID del usuario
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();

                    // Iniciar sesión
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            }

            return View(model);
        }

        // ==== REGISTRO DE USUARIO ====
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.SingleOrDefault(u => u.UserName == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "El usuario ya existe");
                    return View(model);
                }

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                var newUser = new User
                {
                    UserName = model.Username,
                    PasswordHash = hashedPassword
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        // ==== CIERRE DE SESIÓN ====
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }

}