using Microsoft.EntityFrameworkCore;
using Ploomers_Advogados.Data;
using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Repository
{
    public class ProcessoRepository : IProcessoRepository
    {

        private readonly AppDbContext _context;

        public ProcessoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Processo processo)
        {
            await _context.Processos.AddAsync(processo);
            await _context.SaveChangesAsync();
        }

        public async Task<Processo> ObterPorIdAsync(int id)
        {
            return await _context.Processos
                .Include(p => p.Advogado) // Inclui o advogado relacionado
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Processo>> ObterTodosAsync()
        {
            return await _context.Processos
                .Include(p => p.Advogado) // Inclui o advogado relacionado
                .ToListAsync();
        }

        public async Task AtualizarAsync(Processo processo)
        {
            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Processo processo)
        {
            _context.Processos.Remove(processo);
            await _context.SaveChangesAsync();
        }
    }
}

