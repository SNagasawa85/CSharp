using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;
namespace ViewModelFun.Controllers;     //be sure to use your own project's namespace!
    public class HomeController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            string message = "This is a new message that happens to be a string.";  
            message += "Next will follow a bunch of nonsens that doesn't make sense because I am silly.";
            message += "I don't know why I write silly things, but I do";
            
            return View("Index", message);
        }


        [HttpGet]
        [Route("numbers")]

        public IActionResult Numbers()
        {
            int[] nums = new int[]
            {
                12,
                15,
                77,
                53,
                42,
                21,
                11
            };
            return View("Numbers", nums);
        }

        [HttpGet]
        [Route("users")]

        public IActionResult Users()
        {
            string[] users = new string[]
            {
                "Johnny Appleseed",
                "Kevin",
                "Sally Smith",
                "John Wick",
                "Frank",
                "Pepe Silvia"
            };
            return View(users);
        }

        [HttpGet]
        [Route("singleuser")]

        public IActionResult SingleUser()
        {
            User man = new User()
            {
                FirstName = "Charlie",
                LastName = "Unicorn"
            };
            return View(man);
        }
    }