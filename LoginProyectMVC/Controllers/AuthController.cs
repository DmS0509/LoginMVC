using LoginProyectMVC.Data;
using LoginProyectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginProyectMVC.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (foundUser == null || !VerifyPassword(user.Password, foundUser.PasswordHash))
                return Unauthorized("Credenciales incorrectas.");

            var token = GenerateJwtToken(foundUser);
            return Ok(new { Token = token });
        }
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.UserInfo?.Role ?? "Usuario") // Evita valores nulos
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                expires: DateTime.UtcNow.AddHours(1), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

    }
}

public class UserLogin
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public UserInfo UserInfo { get; set; }
}

public class UserInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime CreationDate { get; set; }
    public bool Status { get; set; }
    public string Role { get; set; } // Add this property to fix CS1061
    public User User { get; set; }
}
