using Microsoft.EntityFrameworkCore;
using Ploomers_Advogados.Data;
using Ploomers_Advogados.Models;

using System;

namespace Ploomers_Advogados.Repository
{
    public class AdvogadoRepository : IAdvogadoRepository
    {
        private readonly AppDbContext _context;

        public AdvogadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Advogado advogado)
        {
            await _context.Advogados.AddAsync(advogado);
            await _context.SaveChangesAsync();
        }

        public async Task<Advogado> ObterPorIdAsync(int id)
        {
            //return await _context.Advogados.FindAsync(id);

            return await _context.Advogados
               .Include(a => a.Processos)
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Advogado>> ObterTodosAsync()
        {
            return await _context.Advogados.ToListAsync();
        }

        public async Task AtualizarAsync(Advogado advogado)
        {
            _context.Advogados.Update(advogado);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Advogado advogado)
        {
            _context.Advogados.Remove(advogado);
            await _context.SaveChangesAsync();
        }
    }

}
