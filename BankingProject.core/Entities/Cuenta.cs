using BankingProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingProject.core.Entities
{
    public class Cuenta
    {
        [Key]
        public long Id { get; set; }        
        [MaxLength(10)]
        [RegularExpression(@"\d{10}")]
        public string NumeroCuenta  { get; set; }        
        //public int? UserId { get; set; }
        public virtual User User { get; set; }
        public List<Transaccion> Transacciones { get; set; }
        [DataType(DataType.Currency)]
        public decimal Balace { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
