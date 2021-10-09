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
            #region Configuraciones Tablas
            #region Tabla Users
            builder.Entity<User>().ToTable("Users")
                .Property(x => x.FechaCreacion)
                .HasDefaultValueSql("getdate()");
            builder.Entity<User>().Property(x => x.Activo).HasDefaultValue(true); 
            builder.Entity<User>().Property(x => x.Id).UseIdentityColumn();
            #endregion
            #region Tabla Cuentas
            builder.Entity<Cuenta>().ToTable("Cuentas")
                .Property(x => x.FechaCreacion)
                .HasDefaultValueSql("getdate()");
            builder.Entity<Cuenta>().Property(x => x.Activo).HasDefaultValue(true);
            builder.Entity<Cuenta>().Property(x => x.Balace).HasDefaultValue(500);
            builder.Entity<Cuenta>().Property(x => x.Id).UseIdentityColumn();
            #endregion
            #region Tabla Transferencia
            builder.Entity<Transferencia>().ToTable("Transferencias")
                .Property(x => x.Fecha)
                .HasDefaultValueSql("getdate()");
            builder.Entity<Transferencia>().Property(x => x.Id).UseIdentityColumn();
            #endregion
            #endregion
        }

        public DbSet<User> Users { get; set; }
      
        public DbSet<Cuenta> Cuentas { get; set; }
        
        public DbSet<Transferencia> Transferencias { get; set; }

    }
}
