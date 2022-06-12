using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Http;

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
        List<Dish> all = _context.Dishes.OrderBy(u => u.created_at).ToList();
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
        return View("AddDish");
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
        HttpContext.Session.SetInt32("oneID", oneID);
        return View("EditDish", OneDish);
    }

    [HttpPost]
    [Route("/submitedit")]
    public IActionResult SubmitEdit(Dish editedDish)
    {
        int? editID = HttpContext.Session.GetInt32("oneID");
        int oneID = Convert.ToInt32(editID);
        Dish GetDish = _context.Dishes.First(u => u.DishId == oneID);
        if(ModelState.IsValid)
            {
            GetDish.Name = editedDish.Name;
            GetDish.Chef = editedDish.Chef;
            GetDish.Calories = editedDish.Calories;
            GetDish.Tastiness = editedDish.Tastiness;
            GetDish.Description = editedDish.Description;
            GetDish.updated_at = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
        return View("EditDish", GetDish);
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
