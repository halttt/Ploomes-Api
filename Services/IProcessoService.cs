using Microsoft.AspNetCore.JsonPatch;
using Ploomers_Advogados.Data.Dtos;

namespace Ploomers_Advogados.Services
{
    public interface IProcessoService
    {
        Task<ReadProcessoDto> CadastrarAsync(CreateProcessoDto dto);
        Task<ReadProcessoDto> ObterPorIdAsync(int id);
        Task<IEnumerable<ReadProcessoDto>> ObterTodosAsync();
        Task<bool> AtualizarAsync(int id, JsonPatchDocument<UpdateProcessoDto> patch);
        Task<bool> RemoverAsync(int id);
    }
}
