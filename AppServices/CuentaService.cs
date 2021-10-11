using BankingProject.core.Entities;
using BankingProject.data.Repository;
using BankingProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class CuentaService
    {
        private readonly CuentaRepository _cuentaRepository;
        public CuentaService(CuentaRepository cuentaRepository)
        {
            this._cuentaRepository = cuentaRepository;
        }
        public List<Cuenta> ObtenerCuentasporUsuario(int userId)
        {
            return _cuentaRepository.ObtenerPorUsuario(userId);
        }
        public Cuenta CrearCuenta(User user)
        {
            string numeroCuenta = "";
            Random random = new();
            for (int i = 0; i < 10; i++)
            {
                numeroCuenta+=random.Next(0, 9).ToString();
            }

            var cuenta = new Cuenta()
            {
                NumeroCuenta = numeroCuenta,
                User=user,
                Balace=500
            };

            return _cuentaRepository.Agregar(cuenta);
        }
    }
}
