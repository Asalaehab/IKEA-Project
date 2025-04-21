using IKEA.DAL.Models.IdentityModel;
using IKEA.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager) : Controller
    {
        //Register

        [HttpGet]
        public IActionResult Register() => View();


        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if(!ModelState.IsValid) return View(viewModel);


                var User = new ApplicationUser()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    
                };
               var Result= _userManager.CreateAsync(User).Result;

            if (Result.Succeeded)
                return RedirectToAction("Login");
            else
            {
                foreach(var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(viewModel);
            }
        }
        //Login

        //Sign out
    }
}
