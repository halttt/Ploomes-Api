using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Repository
{
    public interface IAdvogadoRepository
    {
        Task AdicionarAsync(Advogado advogado);
        Task<Advogado> ObterPorIdAsync(int id);
        Task<IEnumerable<Advogado>> ObterTodosAsync();
        Task AtualizarAsync(Advogado advogado);
        Task RemoverAsync(Advogado advogado);
    }

}
