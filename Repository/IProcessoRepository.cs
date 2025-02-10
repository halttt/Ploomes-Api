using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Repository
{
    public interface IProcessoRepository
    {
        Task AdicionarAsync(Processo processo);
        Task<Processo> ObterPorIdAsync(int id);
        Task<IEnumerable<Processo>> ObterTodosAsync();
        Task AtualizarAsync(Processo processo);
        Task RemoverAsync(Processo processo);
    }
}
