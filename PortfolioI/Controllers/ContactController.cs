using Microsoft.AspNetCore.Mvc;
namespace PorfolioI.Controllers;     //be sure to use your own project's namespace!
    public class ContactController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("contact")]     //associated route string (exclude the leading /)
        public ViewResult Contact()
        {
            return View();
        }


        [HttpPost]
        [Route("/contact/send")]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "User");
            // this format is ( "the method you would like to redirect to",  "this specifies the controller that contains the method")
        }
    }