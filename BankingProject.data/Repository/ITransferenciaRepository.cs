using BankingProject.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject.data.Repository
{
    interface ITransferenciaRepository:IGenericRepository<Transferencia>
    {
        List<Transferencia> ObtenerTransferenciasporCuenta(string NoCuenta);        
    }
}
