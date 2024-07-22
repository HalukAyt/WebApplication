using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Entities.Concrete;
using WebApp.Models.RequestModel.Account;

namespace WebApp.User.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Personel> _userManager;
        private readonly SignInManager<Personel> _signInManager;
        private readonly RoleManager<MongoIdentityRole> _roleManager;


#pragma warning disable IDE0290 // Use primary constructor
        public AccountController(UserManager<Personel> userManager,
#pragma warning restore IDE0290 // Use primary constructor
            RoleManager<MongoIdentityRole> roleManager,
            SignInManager<Personel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCreateModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new Personel
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = ""
                };

#pragma warning disable CS8604 // Possible null reference argument.
                var result = await _userManager.CreateAsync(user, model.Password);
#pragma warning restore CS8604 // Possible null reference argument.

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
#pragma warning disable CS8604 // Possible null reference argument.
                    return RedirectToLocal(returnUrl);
#pragma warning restore CS8604 // Possible null reference argument.
                }
            }
            return View(model);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
#pragma warning restore IDE0079 // Remove unnecessary suppression
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning restore CS8604 // Possible null reference argument.
                if (result.Succeeded)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    return RedirectToLocal(returnUrl);
#pragma warning restore CS8604 // Possible null reference argument.
                }
#pragma warning restore IDE0079 // Remove unnecessary suppression
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
