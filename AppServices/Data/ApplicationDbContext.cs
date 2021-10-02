using BankingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

       protected override void OnModelCreating(ModelBuilder builder)
       {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
       }

       public DbSet<User> Users { get; set; }
    }
}
