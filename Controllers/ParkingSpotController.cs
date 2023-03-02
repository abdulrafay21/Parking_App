using Microsoft.AspNetCore.Mvc;

namespace Parking_App.Controllers;

public class ParkingSpotController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}