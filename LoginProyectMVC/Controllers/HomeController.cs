using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginProyectMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoginProyectMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    public IActionResult Roles()
    {
        return View();
    }

    public new IActionResult User()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
