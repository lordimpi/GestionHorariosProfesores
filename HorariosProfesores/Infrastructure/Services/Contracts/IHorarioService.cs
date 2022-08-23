﻿using DataAccess.Data.Entities;

namespace Infrastructure.Services.Contracts
{
    public interface IHorarioService
    {
        Task<ICollection<Horario>> GetAllHorariosAsync();
        Task<Horario> GetHorarioByIdAsync(int? id);
        Task<bool> CreateHorarioAsync(Horario horario);
        Task<bool> UdateHorarioAsync(Horario horario);
        Task<bool> DeleteHorarioByIdAsync(int? id);
    }
}
