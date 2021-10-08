using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using BankingProject.core.Entities;
using BankingProject.Services;
using BankingProjectFinal.Helpers;
using BankingProjectFinal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingProjectFinal.Pages.Security
{
    [AllowAnonymous]
    public class LoginModel : BaseModel
    {
        private readonly ISecurityService _securityService;

        public LoginModel(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [BindProperty]
        public LoginViewModel Login { get; set; }

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return this.RedirectToPage("../Index");
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostLogin()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("../Index");
            }
            if (ModelState.IsValid)
            {
                var result = await _securityService.Login(this.Login.Email);

                if (!result.Activo)
                {
                    ShowNotification("La Cuenta Esta Inactiva, Contactar con Soporte.", "Mantenimiento de Usuarios", NotificationType.error);
                    return Page();
                }

                if (result == null)
                {
                    ShowNotification("Usuario o contraseña invalido.", "Mantenimiento de Usuarios", NotificationType.error);
                    return Page();
                }

                if (!ValidarHelper.ValidarPassword(result.Password, result.Password))
                {
                    if (result.Intentos < result.IntentosMaximos)
                    {
                        await _securityService.IncrementarIntentosYChequearIntentosMaximos(result, result.Password, result.IntentosMaximos);
                    }

                    ShowNotification("Usuario o contraseña invalido.", "Mantenimiento de Usuarios", NotificationType.error);
                    return Page();
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
                                                    new AuthenticationProperties { IsPersistent = true });

                    await _securityService.ResetearIntentosDeUsuario(result);

                    return RedirectToPage("../Index");
                }
            }

            return Page();
        }
        
    }
}
