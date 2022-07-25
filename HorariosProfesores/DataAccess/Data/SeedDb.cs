using DataAccess.Data.Entities;

namespace DataAccess.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;

        public SeedDb(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckProgramasAsync();
        }

        private async Task CheckProgramasAsync()
        {
            if (!_context.Programas.Any())
            {
                _context.Programas.Add(new Programa
                {
                    Programa_Nombre = "Ingenieria de Sistemas",
                    IsActivo = true,
                    Competencias = new List<Competencia>() {
                    new Competencia { Competencia_Nombre = "Ingenieria de Sofware III",
                        IsActive = true },
                    new Competencia { Competencia_Nombre = "Ingenieria de Sofware II",
                        IsActive = true },
                    new Competencia { Competencia_Nombre = "Ingenieria de Sofware I",
                        IsActive = true },
                    new Competencia { Competencia_Nombre = "Introducción a la informática",
                        IsActive = true },
                    new Competencia { Competencia_Nombre = "Calculo 3",
                        IsActive = true },
                    new Competencia { Competencia_Nombre = "Bases de Datos II",
                        IsActive = true }
                    }
                }) ;
                _context.Programas.Add(new Programa { Programa_Nombre = "Ingenieria Automatica", IsActivo = true });
                _context.Programas.Add(new Programa { Programa_Nombre = "Ingenieria Electronica", IsActivo = true });
                _context.Programas.Add(new Programa { Programa_Nombre = "Ingenieria Civil", IsActivo = true });
                await _context.SaveChangesAsync();
            }
        }
    }
}
