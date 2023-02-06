using Microsoft.AspNetCore.Mvc;

namespace Parking_App.Controllers;

public class ProfileController : Controller
{
    private readonly IWebHostEnvironment Environment;

    public ProfileController(IWebHostEnvironment
        environment)
    {

        Environment = environment;
    }

    // GET
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost]
    public IActionResult Index(List<IFormFile> postedFiles)
    {
        string wwwPath = this.Environment.WebRootPath;
        string path = Path.Combine(wwwPath, "Uploads");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        foreach (var file in postedFiles)
        {
            var fileName = Path.GetFileName(file.FileName);
            var pathWithFileName = Path.Combine(path, fileName);
            using (FileStream stream = new
                FileStream(pathWithFileName,
                FileMode.Create))
            {
                file.CopyTo(stream);
                ViewBag.Message = "file uploaded successfully";
            }
        }
        return View();
    }
}