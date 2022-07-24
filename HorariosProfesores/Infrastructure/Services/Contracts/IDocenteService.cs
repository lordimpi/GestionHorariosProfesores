using DataAccess.Data.Entities;

namespace Infrastructure.Services.Contracts
{
    public interface IDocenteService
    {
        Task<ICollection<Docente>> GetAllDocentesAsync();
        Task<Docente> GetDocenteByIdAsync(int? id);
        Task<bool> CreateDocenteAsync(Docente docente);
        Task<bool> UdateDocenteAsync(Docente docente);
        Task<bool> DeleteDocenteByIdAsync(int? id);
    }
}
