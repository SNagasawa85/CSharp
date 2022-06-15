using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;

public class ProductController : Controller
{
    private ProdCatContext _context;
    public ProductController(ProdCatContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("viewproducts")]
    public IActionResult ViewProducts()
    {
        ViewBag.ProdList = _context.Products.ToList();
        return View();
    }

    [HttpPost]
    [Route("/submit/product")]
    public IActionResult SubmitProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("ViewProducts");
        }
        return View("ViewProducts");
    }

    [HttpGet]
    [Route("/view/product/{id}")]
    public IActionResult AddCategory(int id)
    {   
        var OneProduct = _context.Products.Include(p => p.Categories).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductID == id);        
        ViewBag.CatList = _context.Categories.Include(c => c.Products).Where(p => !p.Products.Any(p => p.ProductID == id)).ToList();
        ViewBag.ProductID = id;
        return View(OneProduct);
    }

    [HttpPost]
    [Route("submit/category/assoc/{id}")]
    public IActionResult SubmitNewCategoryAssoc(int id, Association newAssoc)
    {
        newAssoc.ProductID = id;
        _context.Associations.Add(newAssoc);
        _context.SaveChanges();
        return RedirectToAction("ViewProducts");
    }
}