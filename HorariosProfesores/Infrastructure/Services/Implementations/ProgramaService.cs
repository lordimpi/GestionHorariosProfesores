using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Infrastructure.Services.Contracts;

namespace Infrastructure.Services.Implementations
{
    public class ProgramaService : IProgramaService
    {
        private readonly IProgramaRepository _programaRepository;

        public ProgramaService(IProgramaRepository programaRepository)
        {
            _programaRepository = programaRepository;
        }
        public Task<bool> CreatePrograma(Programa programa)
        {
            return _programaRepository.CreatePrograma(programa);
        }

        public Task<bool> DeletePrograma(int? id)
        {
            return _programaRepository.DeletePrograma(id);
        }

        public Task<Programa> GetProgramaById(int? programaId)
        {
            return _programaRepository.GetProgramaById(programaId);
        }

        public Task<ICollection<Programa>> GetProgramas()
        {
            return _programaRepository.GetProgramas();
        }

        public Task<bool> ModifyPrograma(Programa programa)
        {
            return _programaRepository.ModifyPrograma(programa);
        }
    }
}
