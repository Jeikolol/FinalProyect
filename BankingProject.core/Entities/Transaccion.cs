using System;
using System.ComponentModel.DataAnnotations;

namespace BankingProject.core.Entities
{
    public class Transaccion
    {
        [Key]
        public long Id { get; set; }
        public long? CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }        
        [Required(ErrorMessage ="El balance es requerido")]
        public decimal Balance { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public string Comentario { get; set; }
    }
}   
