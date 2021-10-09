using BankingProject.core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProjectFinal.Models
{
    public class TransferenciaViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La cuenta de origen es requerida")]
        public string CuentaOrigen { get; set; }
        [Required(ErrorMessage = "La cuenta de destino es requerida")]
        public string CuentaDestino { get; set; }
        [Required(ErrorMessage = "El monto a pagar es requerido")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "El concepto es requerido")]
        public string Concepto { get; set; }
    }
}
