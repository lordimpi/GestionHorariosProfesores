using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Infrastructure.Services.Contracts;

namespace Infrastructure.Services.Implementations
{
    public class DocenteService : IDocenteService
    {
        private readonly IDocenteRepository _docenteRepository;

        public DocenteService(IDocenteRepository docenteRepository)
        {
            _docenteRepository = docenteRepository;
        }

        public Task<bool> CreateDocenteAsync(User docente)
        {
            return _docenteRepository.CreateDocenteAsync(docente);
        }

        public Task<ICollection<User>> GetAllDocentesAsync()
        {
            return _docenteRepository.GetAllDocentesAsync();
        }

        public Task<User> GetDocenteByIdAsync(int? id)
        {
            return _docenteRepository.GetDocenteByIdAsync(id);
        }

        public Task<bool> UdateDocenteAsync(User docente)
        {
            return _docenteRepository.UdateDocenteAsync(docente);
        }

        public Task<bool> DeleteDocenteByIdAsync(int? id)
        {
            return _docenteRepository.DeleteDocenteByIdAsync(id);
        }
    }
}
