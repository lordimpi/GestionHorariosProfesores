using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly ApplicationDbContext _context;

        public HorarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateHorarioAsync(Horario horario)
        {
            _context.Add(horario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteHorarioByIdAsync(int? id)
        {
            Horario horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return false;
            }
            horario.IsActive = false;
            _context.Update(horario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<Horario>> GetAllHorariosAsync()
        {
            List<Horario> horarios = await _context.Horarios.ToListAsync();
            return horarios;
        }

        public async Task<Horario> GetHorarioByIdAsync(int? id)
        {
            Horario horario = await _context.Horarios.FindAsync(id);
            return horario;
        }

        public async Task<bool> UdateHorarioAsync(Horario horario)
        {
            _context.Entry(horario).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
