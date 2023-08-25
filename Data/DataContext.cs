using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "Usuário 1" },
                new Usuario { Id = 2, Nome = "Usuário 2" },
                new Usuario { Id = 3, Nome = "Usuário 3" }
            );
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
