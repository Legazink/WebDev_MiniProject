using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebDev_MiniProject.Data;
using WebDev_MiniProject.Models;
using WebDev_MiniProject.Models.Entities;

namespace WebDev_MiniProject.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        ViewData["Page"] = "Login";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        username = username.ToLower();
        ViewData["Page"] = "Login";
        var accounts = await _context.Accounts.ToListAsync();
        foreach (var account in accounts)
        {
            if (account.Username == username)
            {
                if (account.Password == password)
                {
                    return RedirectToAction("HomePage", "Home");
                }
            }
        }
        ModelState.AddModelError("", "Invalid Username or Password.");

        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        ViewData["Page"] = "Register";
        return View();
    }

    [HttpPost]
    public IActionResult Register(Account account)
    {
        ViewData["Page"] = "Register";
        _context.Add(account);
        _context.SaveChanges();
        return RedirectToAction("Login");
    }

    public IActionResult HomePage()
    {
        ViewData["Page"] = "Homepage";
        return View();
    }
    [HttpGet]
    public IActionResult CreatePost()
    {
        ViewData["Page"] = "Create";
        return View();
    }
    [HttpPost]
    public IActionResult CreatePost(Post post)
    {
        ViewData["Page"] = "Create";
        _context.Add(post);
        _context.SaveChanges();
        return RedirectToAction("HomePage");
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
