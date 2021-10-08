using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BankingProject.core.Entities;
using BankingProject.Services;
using BankingProjectFinal.Helpers;
using BankingProjectFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingProjectFinal.Pages.Security
{
    [AllowAnonymous]
    public class RegisterModel : BaseModel
    {
        private readonly ISecurityService _securityService;

        public RegisterModel(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [BindProperty]
        public RegisterViewModel Register { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegister()
        {
            if (ModelState.IsValid)
            {
                if (!ValidarHelper.ValidarCedula(this.Register.Cedula))
                {
                    ShowNotification("La Cedula Ingresada es Invalida.", "Mantenimiento de Usuarios", NotificationType.error);
                    return Page();
                }

                var result = await _securityService.CreateUserAsync(this.Register);

                if (result != null)
                {
                    ShowNotification("Usuario Registrado Correctamente.", "Mantenimiento de Usuarios", NotificationType.success);
                    return RedirectToPage("/Security/Login");
                }
            }

            return Page();
        }
    }
}
