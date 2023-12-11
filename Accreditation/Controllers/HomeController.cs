using Accreditation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace Accreditation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        //public void LoginOnClick(object sender, EventArgs e)
        //{
        //    string msg = string.Empty;
        //    string strcon = "Data Source=.;uid=sa;pwd=1;database=Accreditation";
        //    SqlConnection con = new SqlConnection(strcon);
        //    SqlCommand com = new SqlCommand("CheckUserLogin", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlParameter p1 = new SqlParameter("username",username.value)
        //}
    }
}