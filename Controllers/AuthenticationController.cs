using Microsoft.AspNetCore.Mvc;
using Parking_App.Models;

namespace Parking_App.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Signup(string username, string email, string passwd)
        {
            UserAuth userAuth = new UserAuth();
            User? user = userAuth.CreateUser(username, email, passwd);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Error", "User With This Email Already Exists...");
        }

        [HttpPost]
        public IActionResult Login(string email, string passwd)
        {
            UserAuth userAuth = new UserAuth();
            User? user = userAuth.Login(email, passwd);
            if (user != null)
            {
                HttpContext.Response.Cookies.Append("user", user.Username);
                return RedirectToAction("Index", "Home");
            }

            return View("Error", "User does not exist...");
        }
    }
}