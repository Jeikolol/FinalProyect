using BankingProject.core.Entities;
using BankingProject.Data;
using System.Collections.Generic;
using System.Linq;

namespace BankingProject.data.Repository
{
    public class CuentaRepository:GenericRepository<Cuenta>,ICuentaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        List<Cuenta> cuentas = new List<Cuenta>();
        public CuentaRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Cuenta ObtenerPorNumeroCuenta(string numeroCuenta)
        {
            return _dbContext.Cuentas.ToList().Where(x => x.NumeroCuenta == numeroCuenta).FirstOrDefault();
        }
    }
}
