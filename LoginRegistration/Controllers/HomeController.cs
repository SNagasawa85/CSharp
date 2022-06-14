using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.Net.Http;
using Microsoft.AspNetCore.Identity;

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
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            int UserId = newUser.UserId;
            HttpContext.Session.SetInt32("UserId", UserId);
            return RedirectToAction("Success");
        }
        return View("Index");
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    [Route("login/submit")]
    public IActionResult SubmitLogin(LoginUser logUser)
    {
        if(ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == logUser.emailSub);
            if(userInDb == null)
            {
                ModelState.AddModelError("emailSub","Invalid Email/Password");
                return View("Login");
            }
            var hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(logUser, userInDb.Password,logUser.passwordSub);
            if(result == 0)
            {
                ModelState.AddModelError("emailSub", "Invalid Email/Password.");
                return View("Login");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Success");
        }
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

    [HttpGet]
    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
    {
        HttpContext.Session.Clear();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
