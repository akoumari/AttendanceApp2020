using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AttendanceApplication.Models;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace AttendanceApplication.Controllers
{

    public class HomeController : Controller
    {
        //vaiables
        private readonly ILogger<HomeController> _logger;
        public const string SessionKeyName = "_Name";

        public string SessionInfo_Name { get; private set; }
        public string SessionInfo_CurrentTime { get; private set; }
        public string SessionInfo_SessionTime { get; private set; }
        public string SessionInfo_MiddlewareValue { get; private set; }
        public static string Role = "";
        public static string Message = "";
        public static string[] ErrorBag = new string[30];
        
        public Regex rgx = new Regex(@"^[\w\-]+\.csv$");
        public Regex rgxName = new Regex(@"^[\w\-\s]+$");
        //****************************************************

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        



        //Login, Logout, and Register
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
                Message = "Your account was submitted for activation please confirm your account at: " + user.Email;
                return View("Login");
            }
            return View("Register");
        }

        [HttpGet]
        [Route("~/Home/PassReset")]
        public IActionResult GetPassReset()
        {

            return View("PassReset");
        }
        [HttpPost]
        [Route("~/Home/PassReset")]
        public IActionResult PostPassReset(PassResetModel model)
        {
            if (ModelState.IsValid )
            {
                if (model.Email == "eventorg@isp.net" || model.Email == "admin@isp.net")
                {
                    Message = "A password reset was sent to your email at: " + model.Email;
                    return View("Login");
                }
                Message = "The email address: " + model.Email+ " was not found in our system";
                return View("PassReset");
            }
            return View("PassReset");
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
                Message = "";
                return View("Index");
            }
            else if (model.Email == "eventorg@isp.net" && model.Password == "eventorg")
            {
                Role = "eventorg";
                Message = "";
                HttpContext.Session.SetString(SessionKeyName, "eventorg");
                return View("Index");
            }
            else if (model.Email != null && model.Password != null)
            {
                Message = "Invalid email or password";
                return View("Login");
            }
            Message = "";
            return View("Login");

        }


        [HttpGet]
        [Route("~/Home/Logout")]
        public IActionResult Logout()
        {
            Role = "";
            return View("Login");
        }
        //****************************************************

        //Home
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(SessionKeyName) == null || Role == "")
            {
                return View("Login");
            }
            return View();
        }
        //****************************************************

        //EventOrg
        //Attendance Register
        [HttpGet]
        [Route("~/Home/AddRegistry")]
        public IActionResult GetAddRegistry()
        {

            return View("AddRegistry");
        }
        [HttpPost]
        [Route("~/Home/AddRegistry")]
        public IActionResult PostAddRegistry(RegisterModel model)
        {
            for (int i = 0; i < ErrorBag.Length; i++)
            {
                ErrorBag[i] = null;
            }

            if (model.ClassList != null && !rgx.IsMatch(model.ClassList.FileName))
            {
                ErrorBag[0] ="Please only upload CSV files!";
                
            }
            for(int i = 0; i < model.SessionName.Length; i++)
            {
                if(model.SessionName[0] == null)
                {
                    ErrorBag[1] = "Please provide a session name for each session you add!";
                    break;
                }
                if(!rgxName.IsMatch(model.SessionName[i]))
                {
                    ErrorBag[1] = "Please provide a session name for each session you add!"; 
                }
            }
            for (int i = 0; i < model.SessionDescription.Length; i++)
            {
                if (model.SessionDescription[0] == null)
                {
                    ErrorBag[2] = "Please provide a session name for each session you add!";
                    break;
                }
                if (!rgxName.IsMatch(model.SessionDescription[i]))
                {
                    ErrorBag[2] = "Please provide a session description for each session you add!";
                }
            }
            if (ModelState.IsValid && ErrorBag[0] == null && ErrorBag[1] == null && ErrorBag[2] == null)
            {
                for(int i = 0; i < ErrorBag.Length; i++)
                {
                    ErrorBag[i] = null;
                }
                Message = "Attendance register was saved!";
                return View("AttendanceRegistry");
            }
            return View("AddRegistry");
        }
        [HttpGet]
        [Route("~/Home/AttendanceRegistry")]
        public IActionResult GetAttendanceRegistry()
        {
            return View("AttendanceRegistry");
        }
        //***********************
        //Attendance Schema




        //****************************************************

        //Admin
        [HttpGet]
        [Route("~/Home/Admin")]
        public IActionResult GetAdmin()
        {
            return View("Admin");
        }
        [HttpPost]
        [Route("~/Home/Admin")]
        public IActionResult PostAdmin(AdminModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            return View("Admin");
        }
        //****************************************************
        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString(SessionKeyName) == null || Role == "")
            {
                return View("Login");
            }
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
