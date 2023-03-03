using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;
using Parking_App.Models;

namespace Parking_App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
            return View("Index", parkingSpots);
        }

        [HttpGet]
        public ViewResult AboutUs()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SearchParkings(string city_search)
        {
            ParkingRepository pr = new ParkingRepository();     
            List<ParkingSpot> parkings = pr.GetParkingSpotsByCity(city_search);
            return View("Index", parkings);
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

