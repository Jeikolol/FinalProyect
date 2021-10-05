using BankingProject.Helpers;
using BankingProject.Models;
using BankingProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankingProject.Controllers
{
    public class SecurityController : BaseController
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
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
                var result = await _securityService.Login(param.Email, param.Password);

                if (!result.Activo)
                {
                    ShowNotification("La Cuenta Esta Inactiva, Contactar con Soporte.", "Mantenimiento de Usuarios", NotificationType.error);
                    return View();
                }
                
                if (result == null)
                {
                    ShowNotification("Usuario o contraseña invalido.", "Mantenimiento de Usuarios", NotificationType.error);
                    return View();
                }

                if (!ValidarPassword.Validar(result.Password, param.Password))
                {
                    if (result.Intentos < result.IntentosMaximos)
                    {
                        await _securityService.IncrementarIntentosYChequearIntentosMaximos(result, param.Password, result.IntentosMaximos);
                    }

                    ShowNotification("Usuario o contraseña invalido.", "Mantenimiento de Usuarios", NotificationType.error);
                    return View();
                }

                if (result != null)
                {
                    var claims = new[] 
                    { 
                        new Claim(ClaimTypes.Name, result.Correo),
                        new Claim(ClaimTypes.Email, result.Correo),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                                                    new ClaimsPrincipal(identity), 
                                                    new AuthenticationProperties { IsPersistent = true});
                    
                    await _securityService.ResetearIntentosDeUsuario(result);

                    return RedirectToAction("Index", "Home");
                }
            }

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
                    ShowNotification("Usuario Creado Correctamente", "Mantenimiento de Usuarios", NotificationType.success);

                    return LocalRedirect(returnUrl);
                }
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Security");
        }
    }
}
