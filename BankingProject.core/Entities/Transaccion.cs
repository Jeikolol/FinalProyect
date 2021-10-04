using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject.core.Entities
{
    public class Transaccion
    {
        [Key]
        public long Id { get; set; }
        public Cuenta Cuenta { get; set; }        
        public long? CuentaId { get; set; }
        [Required(ErrorMessage ="El balance es requerido")]
        public decimal Balance { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public string Comentario { get; set; }
    }
}   
