using Microsoft.AspNetCore.Mvc;
using Dojosurvey.Models;
namespace DojoSurvey.Controllers;     //be sure to use your own project's namespace!
    public class DojoController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult process(Survey dojosurvey)
        {   
            if(ModelState.IsValid)
            {
                return RedirectToAction("results", dojosurvey);
            }
            else
            {
                return Index();
            }
            
        }

        [HttpGet]
        [Route("results")]

        public IActionResult Results(Survey answer)
        {
            return View(answer);
        }
    }