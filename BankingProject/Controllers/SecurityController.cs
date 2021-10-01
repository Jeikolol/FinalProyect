using BankingProject.Entities;
using BankingProject.Models;
using BankingProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankingProject.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly ISecurityService _securityService;

        public SecurityController(ILogger<SecurityController> logger,
            ISecurityService securityService)
        {
            _logger = logger;
            _securityService = securityService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginModel() { ReturnUrl = returnUrl });
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel param)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _securityService.Login(param);

                if (result != null)
                {
                    var claims = new[] 
                    { 
                        new Claim(ClaimTypes.Name, result.UserName),
                        new Claim(ClaimTypes.Email, result.UserName),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                                                    new ClaimsPrincipal(identity), 
                                                    new AuthenticationProperties { IsPersistent = true});

                    _logger.LogInformation("Usuario logeado.");
                    return RedirectToAction("Index", "Home");
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("Usuario bloqueado.");
                //    return RedirectToPage("./Lockout");
                //}
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public ActionResult Register(string returnUrl)
        {
            return View(new RegisterModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel param, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _securityService.CreateUserAsync(param);

                if (result != null)
                {
                    var login = new LoginModel
                    {
                        UserName = result.UserName,
                        Password = result.Password
                    };

                    _logger.LogInformation("Usuario creado.");

                    await _securityService.Login(login);
                    return LocalRedirect(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}
