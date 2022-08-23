using DataAccess.Data.Entities;

namespace DataAccess.Repositories.Contracts
{
    public interface IAmbienteRepository
    {
        Task<ICollection<Ambiente>> GetAllAmbientesAsync();
        Task<Ambiente> GetAmbienteByIdAsync(int? id);
        Task<bool> CreateAmbienteAsync(Ambiente ambiente);
        Task<bool> UdateAmbienteAsync(Ambiente ambiente);
        Task<bool> DeleteAmbienteByIdAsync(int? id);
    }
}
