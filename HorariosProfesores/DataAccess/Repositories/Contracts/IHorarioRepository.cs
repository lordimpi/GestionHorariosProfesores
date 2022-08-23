using DataAccess.Data.Entities;

namespace DataAccess.Repositories.Contracts
{
    public interface IHorarioRepository
    {
        Task<ICollection<Horario>> GetAllHorariosAsync();
        Task<Horario> GetHorarioByIdAsync(int? id);
        Task<bool> CreateHorarioAsync(Horario horario);
        Task<bool> UdateHorarioAsync(Horario horario);
        Task<bool> DeleteHorarioByIdAsync(int? id);
    }
}
