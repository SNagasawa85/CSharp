using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private WeddingContext _context;
    public HomeController(WeddingContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return RedirectToAction("LogReg", "User");
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
