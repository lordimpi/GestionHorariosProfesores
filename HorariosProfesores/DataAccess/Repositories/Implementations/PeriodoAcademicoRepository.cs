using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class PeriodoAcademicoRepository : IPeriodoAcademicoRepository
    {
        private readonly ApplicationDbContext _context;

        public PeriodoAcademicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico)
        {
            _context.Add(periodoAcademico);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<PeriodoAcademico>> GetAllPeriodosAcamedicosAsync()
        {
            List<PeriodoAcademico> periodoAcademicos = await _context.PeriodoAcademicos
                .Include(pa => pa.Programas.Where(pg => pg.IsActivo == true))
                .ToListAsync();
            return periodoAcademicos;
        }

        public async Task<PeriodoAcademico> GetPeriodoAcamedicoByIdAsync(int? id)
        {
            PeriodoAcademico periodoAcademico = await _context
                .PeriodoAcademicos.FirstOrDefaultAsync(pa => pa.Periodo_Id == id);
            return periodoAcademico;
        }

        public async Task<bool> UpdatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico)
        {
            _context.Entry(periodoAcademico).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePeriodoAcamedicoByIdAsync(int? id)
        {
            PeriodoAcademico periodoAcademico = await _context.PeriodoAcademicos
                                                        .Include(pa => pa.Programas)
                                                        .FirstOrDefaultAsync(pa => pa.Periodo_Id == id);
            if (periodoAcademico == null)
            {
                return false;
            }

            periodoAcademico.IsActive = false;
            _context.Update(periodoAcademico);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
