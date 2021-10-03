using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject.core.Entities
{
    public class Transacciones
    {
        public long Id { get; set; }

        public Cuenta CuentaOrigenId { get; set; }
        public Cuenta CuentaDestinoId { get; set; }

        public decimal Balance { get; set; }

        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }


    }
}   
