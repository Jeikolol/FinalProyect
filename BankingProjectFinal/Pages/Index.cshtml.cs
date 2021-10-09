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
        private readonly ILogger<IndexModel> _logger;
        private readonly CuentaService _cuentaService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<Cuenta> Cuentas { get; set; }
        public int userId { get; set; }

        public IndexModel(ILogger<IndexModel> logger,CuentaService cuentaService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _cuentaService = cuentaService;
            _httpContextAccessor = httpContextAccessor;
            this.userId =int.Parse( _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            this.Cuentas = _cuentaService.ObtenerCuentasporUsuario(userId);
        }

        public void OnGet()
        {      
        }
        
        public async Task<IActionResult> OnPostLogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToPage("Login", "Login");
        }
    }
}
