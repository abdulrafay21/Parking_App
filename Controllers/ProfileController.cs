using Microsoft.AspNetCore.Mvc;

namespace Parking_App.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}