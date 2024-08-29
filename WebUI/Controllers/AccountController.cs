using Domain.Account;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _auth;

        public AccountController(IAuthenticate auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var result = await _auth.RegisterUser(model.Email, model.Password);
            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. (Password must be strong).");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var result = await _auth.Authenticate(model.Email, model.Password);
            if (result)
            {
                if(string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. (Password must be strong).");
                return View(model);
            }
        }

        public async Task<ActionResult> Logout()
        {
            await _auth.LogOut();
            return Redirect("/Account/Login");
        }
    }
}
