using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingProject.core.Entities;
using BankingProject.Data;
using BankingProjectFinal.Models;
using BankingProjectFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace BankingProjectFinal.Pages.Transferencias
{
    public class TransferenciaModel : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ITransferenciaService _transferenciaService;
        private readonly IMemoryCache _memoryCache;

        [BindProperty]
        public TransferenciaViewModel Transferencia { get; set; }

        public TransferenciaModel(ApplicationDbContext context, ITransferenciaService transferenciaService, IMemoryCache memoryCache)
        {
            _context = context;
            _transferenciaService = transferenciaService;
            _memoryCache = memoryCache;
        }

        //public IActionResult OnGet()
        //{
        //    ViewData["listaCuentas"] = new SelectList(_transferenciaService., "id", "listaCuentas");
        //}

        public async Task<IActionResult> OnPostTransferir()
        {
            var result = await _transferenciaService.CrearTransferencia(this.Transferencia);

            ShowNotification("", "", NotificationType.success);

            return Page();
        }
    }
}
