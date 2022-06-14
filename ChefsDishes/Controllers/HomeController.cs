using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers;

public class HomeController : Controller
{
    private ChefContext _context;
    public HomeController(ChefContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> allChefs = _context.Chefs.Include(c => c.CreatedDishes).ToList();
        return View(allChefs);
    }

    [HttpGet]
    [Route("/dishes")]
    public IActionResult dishes()
    {
        List<Dish> allDishes = _context.Dishes.Include(dish => dish.Creator).ToList();
        return View(allDishes);
    }

    [HttpGet]
    [Route("/add/dish")]
    public IActionResult AddDish()
    {
        Dish blankDish = new Dish();
        blankDish.AllChefs = _context.Chefs.ToList();
        return View("AddDish", blankDish);
    }

    [HttpGet]
    [Route("/add/chef")]
    public IActionResult AddChef()
    {
        return View();
    }

    [HttpPost]
    [Route("/submit/dish")]
    public IActionResult SubmitDish(Dish newDish)
    {   
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return AddDish();
    }

    [HttpPost]
    [Route("/submit/chef")]
    public IActionResult SubmitChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Chefs.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddChef");
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
