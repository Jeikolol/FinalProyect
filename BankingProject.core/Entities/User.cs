using System.ComponentModel.DataAnnotations;

namespace BankingProject.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
