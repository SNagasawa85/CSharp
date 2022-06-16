using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private WeddingContext _context;
    public WeddingController(WeddingContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("new/wedding")]
    public IActionResult NewWedding()
    {
        int? loggedIn = HttpContext.Session.GetInt32("UserID");
        if(loggedIn == null)
        {
            ViewBag.NotLoggedIn = "You Must Login or Register to view content.";
            return RedirectToAction("User", "LogReg");
        }
        int userId = Convert.ToInt32(loggedIn);
        ViewBag.UserID = userId;
        return View("NewWedding");
    }

    [HttpPost]
    [Route("add/wedding")]
    public IActionResult AddWedding(Wedding newWedding)
    
    {
        if(ModelState.IsValid)
        {
            _context.Weddings.Add(newWedding);
            _context.SaveChanges();
            return Redirect(string.Format("/view/wedding/{0}", newWedding.WeddingID)) ;
        }
        return NewWedding();
    }

    [HttpGet]
    [Route("/view/wedding/{id}")]
    public IActionResult ViewWedding(int id)
    {
        int? loggedIn = HttpContext.Session.GetInt32("UserID");
        if(loggedIn == null)
        {
            ViewBag.NotLoggedIn = "You Must Login or Register to view content.";
            return RedirectToAction("User", "LogReg");
        }
        APIKey newKey = new APIKey();
        ViewBag.Key = newKey.MyAPIKey;
        Wedding? oneWedding = _context.Weddings.Include(w => w.Users).ThenInclude(a => a.User).FirstOrDefault(w => w.WeddingID == id);
        return View(oneWedding);
    }

    [HttpGet]
    [Route("delete/wedding/{id}")]
    public IActionResult DeleteWedding(int id)
    {
        Wedding? deleteWedding = _context.Weddings.FirstOrDefault(w => w.WeddingID == id);
        _context.Weddings.Remove(deleteWedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard", "User");
    }

    [HttpGet]
    [Route("unrsvp/{id}")]
    public IActionResult UnRSVP(int id)
    {
        int? loggedIn = HttpContext.Session.GetInt32("UserID");
        int userID = Convert.ToInt32(loggedIn);
        List<Association> unRsvp = _context.Associations.Where(a => a.WeddingID == id && a.UserID == userID).ToList();
        Association deleteAssoc = unRsvp[0];
        _context.Associations.Remove(deleteAssoc);
        _context.SaveChanges();
        return RedirectToAction("Dashboard", "User");        
    }

    [HttpGet]
    [Route("rsvp/{id}")]
    public IActionResult RSVP(int id)
    {
        int? loggedIn = HttpContext.Session.GetInt32("UserID");
        int userID = Convert.ToInt32(loggedIn);
        Association newAssoc = new Association();
        newAssoc.WeddingID = id;
        newAssoc.UserID = userID;
        _context.Associations.Add(newAssoc);
        _context.SaveChanges();
        return RedirectToAction("Dashboard", "User");
    }

}