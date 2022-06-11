using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.Net.Http;

namespace LoginRegistration.Controllers;

public class HomeController : Controller
{
    private UserContext _context;
    
    public HomeController(UserContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {   
        return View("Index");
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newUser);
            _context.SaveChanges();
            int UserId = newUser.UserId;
            HttpContext.Session.SetInt32("UserId", UserId);
            RedirectToAction("Success");
        }
        return View("Index");
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("login/submit")]
    public IActionResult SubmitLogin(LoginUser logUser)
    {
        User oneUser = _context.Users.FirstOrDefault(u => u.Email == logUser.emailSub);
        if(oneUser.Password == logUser.passwordSub)
        {
            int UserId = oneUser.UserId;
            HttpContext.Session.SetInt32("UserId", UserId);
            return RedirectToAction("Success");
        }
        ViewBag.ErrorMessage = "Incorrect Email or Password.";
        return View("Login");
    }

    [HttpGet]
    [Route("success")]
    public IActionResult Success()
    {
        int? CurrentUser = HttpContext.Session.GetInt32("UserId");
        if(CurrentUser != null )
        {
            return View();
        }
        ViewBag.ErrorMessage = "Please Login or Register to view Content.";
        return View("Login");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
