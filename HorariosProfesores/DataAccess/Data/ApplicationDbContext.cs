using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            : base(option)
        {

        }

        public DbSet<Programa> Programas { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Programa>().HasIndex(p => p.Programa_Nombre).IsUnique();
            builder.Entity<Competencia>().HasIndex("Competencia_Nombre", "Programa_Id").IsUnique();
        }

    }
}
