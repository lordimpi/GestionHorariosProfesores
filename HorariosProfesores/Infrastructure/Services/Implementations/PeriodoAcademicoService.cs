using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Infrastructure.Services.Contracts;

namespace Infrastructure.Services.Implementations
{
    public class PeriodoAcademicoService : IPeriodoAcademicoService
    {
        private readonly IPeriodoAcademicoRepository _periodoAcademicoRepository;

        public PeriodoAcademicoService(IPeriodoAcademicoRepository periodoAcademicoRepository)
        {
            _periodoAcademicoRepository = periodoAcademicoRepository;
        }

        public async Task<bool> CreatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico)
        {
            return await _periodoAcademicoRepository.CreatePeriodoAcamedicoAsync(periodoAcademico);
        }

        public async Task<bool> DeletePeriodoAcamedicoByIdAsync(int? id)
        {
            return await _periodoAcademicoRepository.DeletePeriodoAcamedicoByIdAsync(id);
        }

        public async Task<ICollection<PeriodoAcademico>> GetAllPeriodosAcamedicosAsync()
        {
            return await _periodoAcademicoRepository.GetAllPeriodosAcamedicosAsync();
        }

        public async Task<PeriodoAcademico> GetPeriodoAcamedicoByIdAsync(int? id)
        {
            return await _periodoAcademicoRepository.GetPeriodoAcamedicoByIdAsync(id);
        }

        public async Task<bool> UpdatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico)
        {
            return await _periodoAcademicoRepository.UpdatePeriodoAcamedicoAsync(periodoAcademico);
        }
    }
}
