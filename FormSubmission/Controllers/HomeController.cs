using Microsoft.AspNetCore.Mvc;
namespace FormSubmission.Controllers;
using FormSubmission.Views;
using FormSubmission.Models;

public class HomeController : Controller
{

    [HttpGet]
    [Route("")]

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("create")]

    public IActionResult Create(User user)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else{
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
