using BankingProject.core.Entities;
using BankingProject.data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class TransferenciaService
    {
        private readonly TransferenciaRepository _transferenciaRepository;
        public TransferenciaService(TransferenciaRepository transferenciaRepository)
        {
            this._transferenciaRepository = transferenciaRepository;
        }
        public List<Transferencia> ObtenerTransferenciasPorCuenta(string NoCuenta) {
            return _transferenciaRepository.ObtenerTransferenciasporCuenta(NoCuenta);
        }
    }
}
