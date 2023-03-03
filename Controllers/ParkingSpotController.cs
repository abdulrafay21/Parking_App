using Microsoft.AspNetCore.Mvc;
using Parking_App.Models;


namespace Parking_App.Controllers;

public class ParkingSpotController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult View(int id)
    {
        ParkingRepository prepo = new ParkingRepository();
        ParkingSpot p = prepo.GetParkingSpot(id);

        return View("View", p); 
    }

    [HttpGet]
    public IActionResult Book(int id)
    {
        ParkingRepository prepo = new ParkingRepository();
        prepo.BookParkingSpot(id);

        return RedirectToAction("Index", "Home");
    }
}