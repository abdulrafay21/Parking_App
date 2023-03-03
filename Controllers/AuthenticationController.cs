using Microsoft.AspNetCore.Mvc;
using Parking_App.Models;

namespace Parking_App.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserRepo userAuth;
        public AuthenticationController(IUserRepo auth)
        {
            userAuth = auth;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Signup(string username, string email, string passwd)
        {
            
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
            //if (ModelState.IsValid)
            //{                
                
                User? user = userAuth.Login(email, passwd);

                if (user != null)
                {
                    HttpContext.Response.Cookies.Append("user", user.Username);
                    HttpContext.Response.Cookies.Append("email", user.Email);
                    HttpContext.Response.Cookies.Append("id", user.Id.ToString());
                    if (user.ProfileName != null)
                    {
                        HttpContext.Response.Cookies.Append("profile", user.ProfileName);
                    }
                    return RedirectToAction("Index", "Home");
                }
                return View("Error", "User does not exist...");
                //}
            //else
            //{
            //    ModelState.AddModelError(String.Empty, "Please enter correct data");
            //    return View("Login");
            //}
        }
    }
}