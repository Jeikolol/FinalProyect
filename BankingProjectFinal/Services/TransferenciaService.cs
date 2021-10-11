using BankingProject.core.Entities;
using BankingProject.Data;
using BankingProject.Infrastructure;
using BankingProject.Services;
using BankingProjectFinal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProjectFinal.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ApplicationDbContext _context;        

        public TransferenciaService(ApplicationDbContext context, ISecurityService securityService)
        {
            _context = context;
        }

        public async Task<Transferencia> CrearTransferencia(TransferenciaViewModel transferencia)
        {


            var cuentaDestinoRecuperada = await _context.Cuentas
                .Where(x => x.NumeroCuenta == transferencia.CuentaDestino)
                .FirstOrDefaultAsync();

            var cuentaOrigenRecuperada = await _context.Cuentas
                .Where(x => x.NumeroCuenta == transferencia.CuentaOrigen)
                .FirstOrDefaultAsync();

            var transferenciaCreada = new Transferencia
            {
                CuentaOrigen = cuentaOrigenRecuperada,
                CuentaDestino = cuentaDestinoRecuperada,
                Monto = transferencia.Monto,
                Concepto = transferencia.Concepto

            };

            cuentaDestinoRecuperada.Balace += transferenciaCreada.Monto;
            cuentaOrigenRecuperada.Balace -= transferenciaCreada.Monto;
            _context.Update(cuentaDestinoRecuperada);
            _context.Update(cuentaOrigenRecuperada);

            _context.Add(transferenciaCreada);
            await _context.SaveChangesAsync();

            return transferenciaCreada;

        }

        /*Task<Cuenta> getCuentasByUser()
        {
        }*/
    }

    public interface ITransferenciaService : IService
    {
        Task<Transferencia> CrearTransferencia(TransferenciaViewModel transferencia);
        //Task<Cuenta> getCuentasByUser();

    }
}
