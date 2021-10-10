using BankingProject.core.Entities;
using BankingProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject.data.Repository
{
    public class TransferenciaRepository : GenericRepository<Transferencia>, ITransferenciaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransferenciaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Transferencia> ObtenerTransferenciasporCuenta(string NoCuenta)
        {
            var transferencias= _dbContext.Transferencias.Include(x=>x.CuentaOrigen).Include(x=>x.CuentaDestino).Where(x => x.CuentaOrigen.NumeroCuenta == NoCuenta || x.CuentaDestino.NumeroCuenta == NoCuenta);
            return transferencias!=null ? transferencias.ToList() : new List<Transferencia>();
        }
    }
}
