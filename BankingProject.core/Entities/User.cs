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
        [Required(ErrorMessage ="El Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El Nombre no puede tener mas de 20 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(20,ErrorMessage ="El apellido no puede tener mas de 20 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage ="La Cedula es requerida")]
        [RegularExpression(@"\d{11}")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "La Direccion es Requerida.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El Telefono es Requerido.")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }
        [DataType(DataType.Date)]        
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int Intentos { get; set; }
        public int IntentosMaximos { get; set; }
    }
}
