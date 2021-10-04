using System;
using System.ComponentModel.DataAnnotations;

namespace BankingProject.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }


    }
}
