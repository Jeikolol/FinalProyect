using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BankingProjectFinal.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(20, ErrorMessage = "El apellido no puede tener mas de 20 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La cedula es requerida")]
        [RegularExpression(@"\d{11}")]
        public string Cedula { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La confirmacion es diferente a la orignal.")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [Required]
        public string Direccion { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }
    }
}
