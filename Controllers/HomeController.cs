using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebDev_MiniProject.Models;

namespace WebDev_MiniProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        ViewData["Page"] = "Login";
        return View();
    }

    public IActionResult Register()
    {
        ViewData["Page"] = "Register";
        return View();
    }

    public IActionResult HomePage()
    {
        ViewData["Page"] = "Homepage";
        return View();
    }
    public IActionResult CreatePost()
    {
        ViewData["Page"] = "Create";
        return View();
    }
    public IActionResult MyPost()
    {
        ViewData["Page"] = "MyPost";
        return View();
    }
    public IActionResult JoinedPost()
    {
        ViewData["Page"] = "Joined";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
