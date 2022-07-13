using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Infrastructure.Services.Contracts;

namespace Infrastructure.Services.Implementations
{
    public class CompetenciaService : ICompetenciaService
    {
        private readonly ICompetenciaRepository _competenciaRepository;

        public CompetenciaService(ICompetenciaRepository competenciaRepository)
        {
            _competenciaRepository = competenciaRepository;
        }

        public async Task<bool> CreateCompetenciaAsync(Competencia competencia)
        {
            return await _competenciaRepository.CreateCompetenciaAsync(competencia);
        }
        public async Task<ICollection<Competencia>> GetAllCompetenciasAsync()
        {
            return await _competenciaRepository.GetAllCompetenciasAsync();
        }
        public async Task<Competencia> GetCompetenciaByIdAsync(int? id)
        {
            return await _competenciaRepository.GetCompetenciaByIdAsync(id);
        }
        public async Task<bool> UdateCompetenciaAsync(Competencia competencia)
        {
            return await _competenciaRepository.UdateCompetenciaAsync(competencia);
        }
        public async Task<bool> DeleteCompetenciaByIdAsync(int? id)
        {
            return await _competenciaRepository.DeleteCompetenciaByIdAsync(id);
        }
    }
}
