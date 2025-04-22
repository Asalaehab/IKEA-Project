using IKEA.DAL.Models.IdentityModel;
using IKEA.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager) : Controller
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
               var Result= _userManager.CreateAsync(User, viewModel.Password).Result;

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
        [HttpGet]
        public IActionResult Login() => View();


        [HttpPost]
        public IActionResult Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid) return View(loginView);
            var User = _userManager.FindByEmailAsync(loginView.Email).Result;
            //_userManager
            if (User is not null)
            {
                bool flag = _userManager.CheckPasswordAsync(User, loginView.Password).Result;
                if (flag)
                {
                   var Result= _signInManager.PasswordSignInAsync(User,loginView.Password,loginView.RememberMe,false).Result;
                    if (Result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty,"your Account Not Allowed ");
                    }
                    if (Result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your Account Is Locked out");

                    if (Result.Succeeded)
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                
            }
            //A$@la0
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
                return View(loginView);
        }

        //Sign out
    }
}
