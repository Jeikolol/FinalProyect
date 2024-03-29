﻿using BankingProject.core.Entities;
using BankingProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BankingProject.data.Repository
{
    public class CuentaRepository:GenericRepository<Cuenta>,ICuentaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        
        public CuentaRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Cuenta ObtenerPorNumeroCuenta(string numeroCuenta)
        {
            return _dbContext.Cuentas.ToList().Where(x => x.NumeroCuenta == numeroCuenta).FirstOrDefault();
        }

        public List<Cuenta> ObtenerPorUsuario(int UserId)
        {
            return _dbContext.Cuentas.Include(x=>x.User).Where(x=>x.User.Id==UserId).ToList();
        }
    }
}
