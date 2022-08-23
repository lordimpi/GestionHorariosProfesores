using DataAccess.Data.Entities;

namespace Infrastructure.Services.Contracts
{
    public interface IAmbienteService
    {
        Task<ICollection<Ambiente>> GetAllAmbientesAsync();
        Task<Ambiente> GetAmbienteByIdAsync(int? id);
        Task<bool> CreateAmbienteAsync(Ambiente ambiente);
        Task<bool> UdateAmbienteAsync(Ambiente ambiente);
        Task<bool> DeleteAmbienteByIdAsync(int? id);
    }
}
