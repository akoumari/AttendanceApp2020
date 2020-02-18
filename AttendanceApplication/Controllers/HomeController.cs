using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AttendanceApplication.Models;

namespace AttendanceApplication.Controllers
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
            if (ViewData["Auth"] == null)
            {
                return this.RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            if (ViewData["Auth"] == null)
            {
                return this.RedirectToAction("Login");
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
        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
