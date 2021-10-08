using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject.core.Entities
{
    public class Transferencia
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La cuenta de origen es requerida")]
        public string cuentaOrigen { get; set; }
        [Required(ErrorMessage = "La cuenta de destino es requerida")]
        public string cuentaDestino { get; set; }
        [Required(ErrorMessage = "El monto a pagar es requerido")]
        public decimal montoAPagar { get; set; }
        [Required(ErrorMessage = "El concepto es requerido")]
        public string concepto { get; set; }
        public List<Cuenta> Cuentas { get; set; }
    }
}
