using Microsoft.AspNetCore.Mvc;
using web.Helpers;
using web.Models.Application;
using web.Models.Auth;

namespace web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = FakeUserStore.Users.FirstOrDefault(x 
                    => x.Username == model.Username && 
                       x.Password == model.Password);
                if (user != null)
                {
                    // Simulate login
                    HttpContext.Session.SetString("Username", user.Username);
                    return RedirectToAction("index", "application");
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public new IActionResult SignOut() 
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction(string.Empty, string.Empty);
        }


        public IActionResult SignUp(CreateAccountModel model)
        {
            return View(model);
        }

        public IActionResult SignInEmployee(SignInEmployeeModel model)
        {
            return View(model);
        }

        public IActionResult Register(CreateAccountModel model)
        {
            // Your custom register logic
            return View(model);
        }
        [HttpPost]
        public IActionResult Profile2(Profile2ViewModel model)
        {
          

            return View(model); // Return to the form if validation fails
        }
    }
}
