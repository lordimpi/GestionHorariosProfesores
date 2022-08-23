using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Infrastructure.Services.Contracts;

namespace Infrastructure.Services.Implementations
{
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;

        public HorarioService(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }
        public async Task<bool> CreateHorarioAsync(Horario horario)
        {
            return await _horarioRepository.CreateHorarioAsync(horario);
        }

        public async Task<bool> DeleteHorarioByIdAsync(int? id)
        {
            return await _horarioRepository.DeleteHorarioByIdAsync(id);
        }

        public async Task<ICollection<Horario>> GetAllHorariosAsync()
        {
            return await _horarioRepository.GetAllHorariosAsync();
        }

        public async Task<Horario> GetHorarioByIdAsync(int? id)
        {
            return await _horarioRepository.GetHorarioByIdAsync(id);
        }

        public async Task<bool> UdateHorarioAsync(Horario horario)
        {
            return await _horarioRepository.UdateHorarioAsync(horario);
        }
    }
}
