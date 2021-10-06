using System.ComponentModel.DataAnnotations;
using BankingProjectFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingProjectFinal.Pages.Security
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        public RegisterViewModel Register { get; set; }

        public void OnGet()
        {
        }
    }
}
