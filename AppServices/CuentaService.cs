using BankingProject.core.Entities;
using BankingProject.data.Repository;
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
    }
}
