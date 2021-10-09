using BankingProject.core.Entities;
using BankingProject.Data;
using BankingProject.Infrastructure;
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

        public TransferenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transferencia> CrearTransferencia(TransferenciaViewModel transferencia)
        {
            var cuentaOrigen = new Cuenta { NumeroCuenta = transferencia.CuentaOrigen };
            var cuentaDestino = new Cuenta { NumeroCuenta = transferencia.CuentaDestino };

            var transferenciaCreada = new Transferencia
            {
                CuentaOrigen = cuentaOrigen,
                CuentaDestino = cuentaDestino,
                Monto = transferencia.Monto,
                Concepto = transferencia.Concepto

            };

            var cuentaDestinoRecuperada = await _context.Cuentas
                .Where(x => x.NumeroCuenta == transferenciaCreada.CuentaDestino.NumeroCuenta)
                .FirstOrDefaultAsync();

            var cuentaOrigenRecuperada = await _context.Cuentas
                .Where(x => x.NumeroCuenta == transferenciaCreada.CuentaOrigen.NumeroCuenta)
                .FirstOrDefaultAsync();

            cuentaDestinoRecuperada.Balace = cuentaDestinoRecuperada.Balace + transferenciaCreada.Monto;
            cuentaOrigenRecuperada.Balace = cuentaOrigenRecuperada.Balace - transferenciaCreada.Monto;

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
