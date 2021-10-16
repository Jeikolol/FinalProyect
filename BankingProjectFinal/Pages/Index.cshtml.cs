using AppServices;
using BankingProject.core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankingProjectFinal.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CuentaService _cuentaService;        
        public List<Cuenta> Cuentas { get; set; }        

        public IndexModel(CuentaService cuentaService, IHttpContextAccessor httpContextAccessor)
        {
  
            _cuentaService = cuentaService;
            var userId =int.Parse( httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            this.Cuentas = _cuentaService.ObtenerCuentasporUsuario(userId);
        }

        public void OnGet()
        {      
        }

        public async Task<IActionResult> OnPostLogOut() {

            await HttpContext.SignOutAsync();

            return RedirectToPage("/Security/Login", "Login");
        }
    }
}
