using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AttendanceApplication.Models;
using Microsoft.AspNetCore.Http;


namespace AttendanceApplication.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string SessionKeyName = "_Name";

        public string SessionInfo_Name { get; private set; }
        public string SessionInfo_CurrentTime { get; private set; }
        public string SessionInfo_SessionTime { get; private set; }
        public string SessionInfo_MiddlewareValue { get; private set; }
        public static string Role = "";
        public string Message { get; set; }

        [HttpGet]
        [Route("~/Home/Logout")]
        public IActionResult Logout()
        {
            Role = "";
            return View("Login");
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(SessionKeyName) == null || Role == "")
            {
                return View("Login");
            }
            return View();
        }
        [HttpGet]
        [Route("~/Home/Admin")]
        public IActionResult GetAdmin()
        {
            return View("Admin");
        }
        [HttpPost]
        [Route("~/Home/Admin")]
        public IActionResult PostAdmin(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Privacy");
            }
            return View("Admin");
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString(SessionKeyName) == null || Role == "")
            {
                return View("Login");
            }
            return View();
        }
        [HttpGet]
        [Route("~/Home/Register")]
        public IActionResult GetRegister()
        {

            return View("Register");
        }
        [HttpPost]
        [Route("~/Home/Register")]
        public IActionResult PostRegister(UserModel user)
        {
            
            
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            return View("Register");
        }
        [HttpGet]
        [Route("~/Home/Login")]
        public IActionResult GetLogin()
        {
            return View("Login");
        }
        [HttpPost]
        [Route("~/Home/Login")]
        public IActionResult PostLogin(UserModel model)
        {
            
            if (model.Email == "admin@isp.net" && model.Password == "admin")
            {
                HttpContext.Session.SetString(SessionKeyName, "admin");
                Role = "admin";
                
                return View("Index");
            }
            else if (model.Email == "eventorg@isp.net" && model.Password == "eventorg")
            {
                Role = "eventorg";
                HttpContext.Session.SetString(SessionKeyName, "eventorg");
                return View("Index");
            }
            else if(model.Email != null && model.Password != null)
            {
                Message = "Invalid email or password";
                return View("Login");
            }
            //Message = "";
            return View("Login");
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
