using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppServices;
using BankingProject.core.Entities;
using BankingProject.Data;
using BankingProjectFinal.Models;
using BankingProjectFinal.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace BankingProjectFinal.Pages.Transferencias
{
    public class TransferenciaModel : BaseModel
    {
        private readonly ITransferenciaService _transferenciaService;
        public List<SelectListItem> cuentasUsuario { get; set; }


        [BindProperty]
        public TransferenciaViewModel Transferencia { get; set; }

        public TransferenciaModel(ITransferenciaService transferenciaService,CuentaService cuentaService, IHttpContextAccessor httpContextAccessor)
        {
            _transferenciaService = transferenciaService;
            var userId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            var cuentas = cuentaService.ObtenerCuentasporUsuario(userId);           
            cuentasUsuario = new List<SelectListItem>();
            foreach (var item in cuentas)
            {
                this.cuentasUsuario.Add(new SelectListItem(item.NumeroCuenta, item.NumeroCuenta));
            }
        }

        public async Task<IActionResult> OnPostTransferir()
        {
            await _transferenciaService.CrearTransferencia(this.Transferencia);

            ShowNotification("La transferencia fue completada con exito!", "!Completado", NotificationType.success);

            return Page();
        }

        public async Task<IActionResult> OnPostLogOut()
        {

            await HttpContext.SignOutAsync();

            return RedirectToPage("/Security/Login", "Login");
        }
    }
}
