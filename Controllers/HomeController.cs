using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Parking_App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AboutUs()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(-3d);
            HttpContext.Response.Cookies.Append("user", "", options = options);
            HttpContext.Response.Cookies.Append("email", "", options = options);
            return RedirectToAction("Login", "Authentication");
        }
    }
}

