using Accreditation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace Accreditation.Controllers
{
    public class HomeController : Controller
    {
        Data data = new Data();
        AccreditationContext context = new AccreditationContext();
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
            int res = data.LoginCheck(accountuser);
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

        public IActionResult Register()
        {
            
            var getRolesList = context.Roles.ToList();
            //SelectList list = new SelectList(getRolesList, "RoleId", "Roles");
            //ViewBag.RoleId = list;
            ViewBag.RoleId = new SelectList(getRolesList, "RoleId", "Roles");

            return View();
        }
        [HttpPost]
        public IActionResult Register([Bind] AccUser accountuser, Role role)
        {
            var getRolesList = context.Roles.ToList();
            ViewBag.RoleId = new SelectList(getRolesList, "RoleId", "Roles");
            bool validEmail = data.isValidEmail(accountuser.Email);
            if (validEmail == true)
            {
                int res = data.RegisterCheck(accountuser);
                
                if (res == 0)
                {
                    data.AddRegisterUser(accountuser, role);
                    TempData["msg"] = "Welcome to Accreditation System";
                    RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["msg"] = "Your email or user id is registered in the system!";
                    return View();

                }
            }
            else
            {
                TempData["msg"] = "Your email is invalid!";
                return View();
            }
            return View();

        }
        
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new AccreditationModels { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}