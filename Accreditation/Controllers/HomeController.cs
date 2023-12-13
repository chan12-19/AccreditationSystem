using Accreditation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace Accreditation.Controllers
{
    public class HomeController : Controller
    {
        CheckDB checkDB = new CheckDB();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind]AccUser accountuser)
        {
            int res = checkDB.LoginCheck(accountuser);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Accreditation System";

            }
            else
            {
                TempData["msg"] = "Your user id or password is invalid!";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new AccreditationModels { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}