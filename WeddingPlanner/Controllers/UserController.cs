using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers;

public class UserController : Controller
{
    private WeddingContext _context;
    public UserController(WeddingContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("LogReg")]
    public IActionResult LogReg()
    {
        List<Wedding> expWeddings = _context.Weddings.Where(w => w.WeddingDate.Date < DateTime.Now.Date).ToList();
        if(expWeddings.Count() < 1)
        {
            return View("LogReg");
        }
        foreach(Wedding one in expWeddings)
        {
            _context.Weddings.Remove(one);
            _context.SaveChanges();
        }
        return View("LogReg");
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if( _context.Users.Any(u => u.Email == newUser.Email))
            { 
                ModelState.AddModelError("Email", " is already in use!");
                return LogReg();
            }
            PasswordHasher<User> PwHash = new PasswordHasher<User>();
            newUser.Password = PwHash.HashPassword(newUser, newUser.Password);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserID", newUser.UserID);
            return RedirectToAction("Dashboard");
        }
        return LogReg();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(LogUser newLogUser)
    {
        if(ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == newLogUser.LogEmail);
            if(userInDb == null)
            {
                ModelState.AddModelError("Email","Invalid Email or Password");
                return LogReg();
            }
            var PwHash = new PasswordHasher<LogUser>();
            var result = PwHash.VerifyHashedPassword(newLogUser, userInDb.Password,newLogUser.LogPassword);
            if(result == 0 ){
                ModelState.AddModelError("Email","Invalid Email or Password");
                return LogReg();
            }
            HttpContext.Session.SetInt32("UserID", userInDb.UserID);
            return RedirectToAction("Dashboard");
        }
        return LogReg();
    }

    [HttpGet]
    [Route("dashboard")]
    public IActionResult Dashboard()
    {
        int? loggedIn = HttpContext.Session.GetInt32("UserID");
        if(loggedIn == null)
        {
            ViewBag.NotLoggedIn = "You Must Login or Register to view content.";
            return LogReg();
        }
        ViewBag.LoggedIn = loggedIn;
        List<Wedding> allWeddings = _context.Weddings.Include(w => w.Users).ThenInclude(a => a.User).ToList();
        return View("Dashboard", allWeddings);
    }


    [HttpGet]
    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LogReg");
    }

}