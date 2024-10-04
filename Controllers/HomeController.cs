using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using WebDev_MiniProject.Data;
using WebDev_MiniProject.Models;
using WebDev_MiniProject.Models.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;


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
    public async Task<IActionResult> HomePage()
    {
        if (User.Identity.IsAuthenticated)
        {
            var allPosts = await _context.Posts
                .Include(p => p.JoinedAllPosts)
                .Include(p => p.Account)
                .Select(p => new {
                    p.GameName,
                    PostOwner = p.Account.UserName,
                    p.JoinedNumber,
                    p.Number,
                    p.Place,
                    p.Date,
                    p.Time,
                    p.PostId,
                    PostJoinedAll = _context.JoinedAllPosts
                    .Where(jp => jp.Post.PostId == p.PostId)
                    .Select(jp => new
                    {
                        JoinedUserName = jp.Account.UserName,
                    })
                    .ToList()
                })
                .ToListAsync(); 
            ViewData["Page"] = "Homepage";
            return View(allPosts); // ส่ง allPosts ไปยัง View
        }

        // หากผู้ใช้ไม่ได้ล็อกอิน จะเปลี่ยนเส้นทางไปยังหน้าล็อกอิน
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult CreatePost()
    {
        ViewData["Page"] = "Create";
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        ViewData["Page"] = "Create";
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            post.Account = user;
            _context.Add(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("HomePage");
        }
        
        return RedirectToAction("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Join(Guid postId)
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
            JoinedAllPost joined = new JoinedAllPost();
            joined.Account = user;
            joined.Post = post;
            List<JoinedAllPost> AllJoined = _context.JoinedAllPosts
                .Where(jp => jp.Post.PostId == postId)
                .ToList();
            post.JoinedNumber = AllJoined.Count + 2;
            _context.Add(joined);
            await _context.SaveChangesAsync();

            return RedirectToAction("HomePage");
        }
        return RedirectToAction("Login");
    }



    public async Task<IActionResult> MyPost()
    {
        var accountID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var myPosts = await _context.Posts
            .Where(post => post.Account.Id == accountID)
            .Select(post => new
            {
                post.PostId,
                post.GameName,
                post.JoinedNumber,
                post.Number,
                post.Place,
                post.Date,
                post.Time,
                Username = post.Account.UserName
            })
            .ToListAsync();

        ViewData["Page"] = "MyPost";
        return View(myPosts); // ส่ง myPosts ไปยัง View
    }

    [HttpPost]
    public IActionResult GetPostMembers(string postId)
    {
        

        Console.WriteLine("Received Post ID: " + postId);
        if (!string.IsNullOrEmpty(postId))
        {
            Console.WriteLine("PostId Not Empty");
            Guid guidPost = Guid.Parse(postId);
            var joinedMembers = _context.JoinedAllPosts
            .Where(j => j.Post.PostId == guidPost)
            .Select(j => new
            {
                j.Account.Id,
                Username = _context.Users.Where(u => u.Id == j.Account.Id).Select(u => u.UserName).FirstOrDefault()
            })
            .ToListAsync();
            return Json(new {joinedMembers});
        }

        return Error();
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
