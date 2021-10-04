using System;
using System.ComponentModel.DataAnnotations;

namespace BankingProject.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="El nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El nombre no puede tener mas de 20 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(20,ErrorMessage ="El apellido no puede tener mas de 20 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage ="La cedula es requerida")]
        [RegularExpression(@"\d{11}")]
        public string Cedula { get; set; }
        [DataType(DataType.Date)]        
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }


    }
}
