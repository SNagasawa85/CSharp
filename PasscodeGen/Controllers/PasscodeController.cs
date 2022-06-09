namespace PasscodeGen.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


public class PasscodeController : Controller 
{
    [HttpGet]
    [Route("")]

    public IActionResult Index()
    {
        if(HttpContext.Session.GetInt32("NewPass") == null)
        {
            HttpContext.Session.SetInt32("NewPass", 1); 
        }
        else
        {
            int? count = HttpContext.Session.GetInt32("NewPass");
            int newCount = Convert.ToInt32(count);
            newCount += 1;
            HttpContext.Session.SetInt32("NewPass", newCount);
        }
        Random rand = new Random();
        string grabFrom = "0123456789ABCDEFGHIJKLMOPQRSTUVWXYZ";
        string NewPass = "";
        for(int i = 0; i<15; i++)
        {
            NewPass += grabFrom[rand.Next(0, grabFrom.Length)];
        }
        return View("Index", NewPass);
    }

    [HttpPost]
    [Route("NewPassword")]
    public IActionResult NewPassword()
    {
        return RedirectToAction("Index");
    }
}