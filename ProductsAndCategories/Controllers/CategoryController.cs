using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;


namespace ProductsAndCategories.Controllers;

public class CategoryController : Controller
{
    private ProdCatContext _context;
    public CategoryController(ProdCatContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("view/categories")]
    public IActionResult ViewCategories()
    {
        ViewBag.CatList = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    [Route("submit/category")]
    public IActionResult SubmitCategory(Category newCategory)
    {
        if(ModelState.IsValid)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("ViewCategories");
        }
        return View("ViewCategories");
    }

    [HttpGet]
    [Route("view/category/{id}")]
    public IActionResult AddProduct(int id)
    {
        var OneCategory = _context.Categories.Include(c => c.Products).ThenInclude(a => a.Product).FirstOrDefault(c => c.CategoryID == id);
        ViewBag.ProdList = _context.Products.Include(p => p.Categories).Where(c => !c.Categories.Any(c => c.CategoryID == id)).ToList();
        ViewBag.CategoryId = id;
        return View("AddProduct",OneCategory);
    }

    [HttpPost]
    [Route("submit/product/assoc/{id}")]
    public IActionResult SubmitNewProductAssoc(int id, Association newAssoc)
    {
        newAssoc.CategoryID = id;
        _context.Associations.Add(newAssoc);
        _context.SaveChanges();
        return RedirectToAction("ViewCategories");
    }
}