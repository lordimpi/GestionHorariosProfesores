using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Infrastructure.Services.Contracts;

namespace Infrastructure.Services.Implementations
{
    public class AmbienteService : IAmbienteService
    {
        private readonly IAmbienteRepository _ambienteRepository;

        public AmbienteService(IAmbienteRepository ambienteRepository)
        {
            _ambienteRepository = ambienteRepository;
        }

        public async Task<bool> CreateAmbienteAsync(Ambiente ambiente)
        {
            return await _ambienteRepository.CreateAmbienteAsync(ambiente);
        }

        public async Task<bool> DeleteAmbienteByIdAsync(int? id)
        {
            return await _ambienteRepository.DeleteAmbienteByIdAsync(id);
        }

        public async Task<ICollection<Ambiente>> GetAllAmbientesAsync()
        {
            return await _ambienteRepository.GetAllAmbientesAsync();
        }

        public async Task<Ambiente> GetAmbienteByIdAsync(int? id)
        {
            return await _ambienteRepository.GetAmbienteByIdAsync(id);
        }

        public async Task<bool> UdateAmbienteAsync(Ambiente ambiente)
        {
            return await _ambienteRepository.UdateAmbienteAsync(ambiente);
        }
    }
}
