using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.ViewModels;
using User.Models;

namespace User.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Account> signInManager;
        private readonly UserManager<Account> userManager;
        public AccountController(SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View(new Register());
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                Account account = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(account, model.Password!);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(account, false);

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe!, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Failed to login");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
