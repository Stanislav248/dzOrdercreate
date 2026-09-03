using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
                string userData = $"Name: {model.Name}, Email: {model.Email}, Age: {model.Age}, Phone: {model.Phone}, CustomLine: {model.CustomLine}\n";

                System.IO.File.AppendAllText(filePath, userData);

                return View("Confirm", model);
            }
            return View(model);
        }
    }
}
