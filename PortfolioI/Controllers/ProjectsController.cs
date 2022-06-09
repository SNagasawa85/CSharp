using Microsoft.AspNetCore.Mvc;
namespace PorfolioI.Controllers;     //be sure to use your own project's namespace!
    public class ProjectsController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("projects")]     //associated route string (exclude the leading /)
        public ViewResult Projects()
        {
            return View();
        }
    }