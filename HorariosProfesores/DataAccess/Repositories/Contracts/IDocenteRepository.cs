using DataAccess.Data.Entities;

namespace DataAccess.Repositories.Contracts
{
    public interface IDocenteRepository
    {
        Task<ICollection<User>> GetAllDocentesAsync();
        Task<User> GetDocenteByIdAsync(int? id);
        Task<bool> CreateDocenteAsync(User docente);
        Task<bool> UdateDocenteAsync(User docente);
        Task<bool> DeleteDocenteByIdAsync(int? id);
    }
}
