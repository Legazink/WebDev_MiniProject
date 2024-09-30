using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    private readonly SignInManager<Account> _signInManager;
    private readonly UserManager<Account> _userManager;
    public HomeController(ApplicationDbContext context, SignInManager<Account> signInManager, UserManager<Account> userManager)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
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
        ViewData["Page"] = "Login";
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("HomePage");
            }
        }
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        if (User.Identity.IsAuthenticated)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        return RedirectToAction("Error");
    }

    [HttpGet]
    public IActionResult Register()
    {
        ViewData["Page"] = "Register";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(string username, string password)
    {
        ViewData["Page"] = "Register";
        if (ModelState.IsValid)
        {
            var user = new Account { UserName = username };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("HomePage");
            }
        }
        return View();
    }
    public IActionResult HomePage()
    {
        if (User.Identity.IsAuthenticated)
        {
        IEnumerable <Post> allPost = _context.Posts;
        ViewData["Page"] = "Homepage";
        return View(allPost);
        }
        return RedirectToAction("Login");
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
