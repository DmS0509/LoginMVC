using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginProyectMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Administrator()
        {
            return View();
        }

        public IActionResult AdminRoles()
        {
            return View();
        }

        public IActionResult RolesAdmin()
        {
            return View();
        }
    }
}
