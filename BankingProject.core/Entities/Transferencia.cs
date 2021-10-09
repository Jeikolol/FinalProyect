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
        public Cuenta CuentaOrigen { get; set; }
        [Required(ErrorMessage = "La cuenta de destino es requerida")]
        public Cuenta CuentaDestino { get; set; }
        [Required(ErrorMessage = "El monto a pagar es requerido")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "El concepto es requerido")]
        public string Concepto { get; set; }

        /*public static implicit operator Transferencia(Transferencia v)
        {
            throw new NotImplementedException();
        }*/

        /*public static implicit operator Transferencia(Transferencia v)
        {
            throw new NotImplementedException();
        }*/
    }
}
