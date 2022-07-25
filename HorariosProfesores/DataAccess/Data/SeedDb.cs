using DataAccess.Data.Entities;
using DataAccess.Data.Enums;
using MiniSIMCA.Helpers;

namespace DataAccess.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelperDA _userHelper;

        public SeedDb(ApplicationDbContext context, IUserHelperDA userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckProgramasAsync();
            await CheckRolesAsync();

            await CheckUserAsync("Santiago", "Acuña", "C.C", "1061752189", "Profesional", "PT", "Desarrollo de Software", true, "snt-26@hotmail.com", UserType.Admin);
            await CheckUserAsync("Camilo", "Daza", "C.C", "1066652189", "Profesional", "PT", "Desarrollo de Software", true, "daza@hotmail.com", UserType.Admin);
            await CheckUserAsync("docente1", "docente1", "C.C", "1061894903", "Tecnico", "CNT", "Gastronomia", true, "docente1@yopmail.com", UserType.User);
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
                });
                _context.Programas.Add(new Programa { Programa_Nombre = "Ingenieria Automatica", IsActivo = true });
                _context.Programas.Add(new Programa { Programa_Nombre = "Ingenieria Electronica", IsActivo = true });
                _context.Programas.Add(new Programa { Programa_Nombre = "Ingenieria Civil", IsActivo = true });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(string nombres, string apellidos, string tipoIdentificacion, string identificacion,
            string tipoDocente, string tipoContrato, string area, bool isActivo, string email, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Docente_Nombres = nombres,
                    Docente_Apellidos = apellidos,
                    Docente_TipoIdentificacion = tipoIdentificacion,
                    Docente_Identificacion = identificacion,
                    Docente_Tipo = tipoDocente,
                    Docente_TipoContrato = tipoContrato,
                    Docente_Area = area,
                    IsActive = isActivo,
                    Email = email,
                    UserName = email,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }
    }
}
