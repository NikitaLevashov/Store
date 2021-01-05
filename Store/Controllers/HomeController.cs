using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data;
using Store.Repository;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository; 

        public IConfiguration Configuration { get; }
    
        public HomeController(IRepository repository, IConfiguration configuration)
        {
            _repository = repository ?? throw new ArgumentNullException();
            Configuration = configuration;
        }

        public IActionResult GetCatalogWithProduct(string catalog)
        {
            IEnumerable<Products> products = _repository.GetProducts(catalog);
            return View(products);
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

                return Redirect("Home");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Contacts()
        {
           return View("Contacts");
        }
            
        public IActionResult About()
        {
            return View("About");
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
