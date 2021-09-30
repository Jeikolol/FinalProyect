using BankingProject.Data;

namespace BankingProject.Infrastructure
{
    public class Service : IService
    {
        protected readonly ApplicationDbContext Database;

        public Service(ApplicationDbContext _Database)
        {
            Database = _Database;
        }

    }
}
