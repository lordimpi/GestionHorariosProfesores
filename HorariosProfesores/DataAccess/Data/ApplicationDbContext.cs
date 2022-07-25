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
        public DbSet<PeriodoAcademico> PeriodoAcademicos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<PeriodoAcademicoPrograma> PeriodoAcademicoProgramas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Programa>().HasIndex(p => p.Programa_Nombre).IsUnique();
            builder.Entity<Competencia>().HasIndex("Competencia_Nombre", "Programa_Id").IsUnique();
            builder.Entity<PeriodoAcademico>().HasIndex(pa => pa.Periodo_Nombre).IsUnique();
            builder.Entity<PeriodoAcademicoPrograma>().HasKey(pAp => new { pAp.PeriodoAcademicoId, pAp.ProgramaId });
            builder.Entity<Docente>().HasIndex(d => d.Docente_Identificacion).IsUnique();
        }

    }
}
