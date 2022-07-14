using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class PeriodoAcamedicoRepository : IPeriodoAcademico
    {
        private readonly ApplicationDbContext _context;
        public PeriodoAcamedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico)
        {
            _context.Add(periodoAcademico);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeletePeriodoAcamedicoByIdAsync(int? id)
        {
            PeriodoAcademico periodoAcademico = await _context.PeriodoAcademicos
                .Include(pa => pa.Programas)
                .FirstOrDefaultAsync(pa => pa.Id == id);

            if (periodoAcademico == null)
            {
                return false;
            }
            periodoAcademico.IsActive = false;
            _context.Update(periodoAcademico);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<ICollection<PeriodoAcademico>> GetAllPeriodosAcamedicosAsync()
        {
            return await _context.PeriodoAcademicos
                .Include(pa => pa.Programas)
                .ToListAsync();
        }
        public async Task<PeriodoAcademico> GetPeriodoAcamedicoByIdAsync(int? id)
        {
            PeriodoAcademico periodoAcademico = await _context.PeriodoAcademicos
            .Include(pa => pa.Programas)
            .FirstOrDefaultAsync(pa => pa.Id == id);
            return periodoAcademico;
        }
        public async Task<bool> UpdatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico)
        {
            _context.Entry(periodoAcademico).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
