using Microsoft.AspNetCore.Mvc;
namespace DateValidator.Controllers;
using DateValidator.Models;

public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost]
    [Route("process")]
    public IActionResult Process(NewDate imDumb)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet]
    [Route("success")]
    public IActionResult Success()
    {
        return View();
    }
}