using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServices;
using BankingProject.core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingProjectFinal.Pages.Historico
{
    public class HistoricoModel : PageModel
    {
        private readonly TransferenciaService _transferenciaService;
        public List<Transferencia> transferencias { get; set; } = new List<Transferencia>();
        public string NoCuenta { get; set; }
        public HistoricoModel(TransferenciaService transferenciaService)
        {
            this._transferenciaService = transferenciaService;            
        }
        public void OnGet(string noCuenta="")
        {
            this.NoCuenta = noCuenta;
            this.transferencias = this._transferenciaService.ObtenerTransferenciasPorCuenta(noCuenta);
        }

        public async Task<IActionResult> OnPostLogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToPage("/Security/Login", "Login");
        }
    }
}
