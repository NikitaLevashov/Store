using System;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Models;
using Microsoft.AspNetCore.Http;

namespace Store.Controllers
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
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Home(string valueName)
        {
            string _userKey = "userName";
                       
            if (!string.IsNullOrEmpty(valueName))
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(_userKey, valueName, cookieOptions);

                //при помощи Session
                //HttpContext.Session.SetString(_userKey, valueName);

                return View();
            }
            else
            {
                return View("Перезагрузите страницу и введите имя.");
            }

        }

        public IActionResult Contacts()
        {
           return View();
        }

        public IActionResult About()
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
