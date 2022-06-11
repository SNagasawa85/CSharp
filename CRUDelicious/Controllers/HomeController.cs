using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private DishContext _context;
    public HomeController(DishContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> all = _context.Dishes.ToList();
        return View(all);
    }

    [HttpGet]
    [Route("/add/dish")]
    public IActionResult AddDish()
    {
        return View("AddDish");
    }

    [HttpPost]
    [Route("/process")]
    public IActionResult SubmitDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return RedirectToAction("AddDish");
    }

    [HttpGet]
    [Route("/view/{oneID}")]
    public IActionResult ViewDish(int oneID)
    {
        Dish OneDish = _context.Dishes.FirstOrDefault(u => u.DishId == oneID);
        return View(OneDish);
    }

    [HttpGet]
    [Route("/edit/{oneID}")]
    public IActionResult EditDish(int oneID)
    {
        Dish OneDish = _context.Dishes.FirstOrDefault(u => u.DishId == oneID);
        return View(OneDish);
    }

    [HttpPost]
    [Route("/submit/edit/{oneID}")]
    public IActionResult SubmitEdit(int oneID, Dish editedDish)
    {
        if(ModelState.IsValid)
            {
            Dish GetDish = _context.Dishes.FirstOrDefault(u => u.DishId == oneID);
            GetDish.Name = editedDish.Name;
            GetDish.Chef = editedDish.Chef;
            GetDish.Tastiness = editedDish.Tastiness;
            GetDish.Calories = editedDish.Calories;
            GetDish.Description = editedDish.Description;
            GetDish.updated_at = editedDish.created_at;
            return RedirectToAction("Index");
            }
        return RedirectToAction("EditDish");
    }

    [HttpGet]
    [Route("/delete/{oneID}")]
    public IActionResult DeleteDish(int oneID)
    {
        Dish GetDish = _context.Dishes.SingleOrDefault(u =>u.DishId == oneID);
        _context.Dishes.Remove(GetDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
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
