using Microsoft.AspNetCore.Mvc;
using Parking_App.Models;

namespace Parking_App.Controllers;

public class ProfileController : Controller
{
    private readonly IWebHostEnvironment Environment;
    private readonly IUserRepo userAuth;

    public ProfileController(IWebHostEnvironment environment, IUserRepo user)
    {
        Environment = environment;
        userAuth = user;
    }

    [HttpGet]
    public IActionResult Index()
    {
        
        long userId = (long)int.Parse(HttpContext.Request.Cookies["id"]);
        User user = userAuth.GetUser(userId);
        return View("Index", user);
    }
    
    [HttpPost]
    public IActionResult Index([FromForm] string name, [FromForm] string email, [FromForm] IFormFile profile)
    {
        long userId = (long)int.Parse(HttpContext.Request.Cookies["id"]);
        string fileName = null;

        if (profile != null) {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, "" + userId);
            Directory.CreateDirectory(path);

            fileName = "profile" + Path.GetExtension(profile.FileName);

            var pathWithFileName = Path.Combine(path, fileName);
            using (FileStream stream = new
            FileStream(pathWithFileName,
            FileMode.Create))
            {
            profile.CopyTo(stream);
            ViewBag.Message = "file uploaded successfully";
            }
        }


        
        userAuth.SaveProfileData(userId,name, email, fileName);

        HttpContext.Response.Cookies.Append("user", name);
        HttpContext.Response.Cookies.Append("email", email);

        return RedirectToAction("Index", "Home");
    }
}