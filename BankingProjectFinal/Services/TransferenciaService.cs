using BankingProject.core.Entities;
using BankingProject.Data;
using BankingProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProjectFinal.Services
{
    public class TransferenciaService
    {
        private readonly ApplicationDbContext _context;

        public TransferenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transferencia> crearTransferencia(Transferencia transferencia)
        {
            var transferenciaCreada = new Transferencia
            {
                cuentaOrigen = transferencia.cuentaOrigen,
                cuentaDestino = transferencia.cuentaDestino,
                montoAPagar = transferencia.montoAPagar,
                concepto = transferencia.concepto

            };

            var cuentaRecuperada = await _context.Cuentas
            .Where(x => x.NumeroCuenta == transferenciaCreada.cuentaDestino)
            .FirstOrDefaultAsync();

            cuentaRecuperada.Balace = cuentaRecuperada.Balace + transferenciaCreada.montoAPagar;

            _context.Update(cuentaRecuperada);
            await _context.SaveChangesAsync();


            _context.Add(transferenciaCreada);
            await _context.SaveChangesAsync();

            return transferenciaCreada;

        }
    }

    public interface ITransferenciaService : IService
    {
        Task<Transferencia> crearTransferencia(Transferencia transferencia);
    }
}
