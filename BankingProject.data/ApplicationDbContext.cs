using BankingProject.core.Entities;
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
            builder.Entity<Cuenta>().ToTable("Cuentas");
            builder.Entity<Transaccion>().ToTable("Transacciones");
        }

       public DbSet<User> Users { get; set; }
      
       public DbSet<Cuenta> Cuentas { get; set; }

       public DbSet<Transaccion> Transacciones { get; set; }

    }
}
