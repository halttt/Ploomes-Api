using Microsoft.AspNetCore.JsonPatch;
using Ploomers_Advogados.Data.Dtos;

namespace Ploomers_Advogados.Services
{
    public interface IAdvogadoService
    {
        Task<ReadAdvogadoDto> CadastrarAsync(CreateAdvogadoDto dto);
        Task<ReadAdvogadoDto> ObterPorIdAsync(int id);
        Task<IEnumerable<ReadAdvogadoDto>> ObterTodosAsync();
        Task<bool> AtualizarAsync(int id, JsonPatchDocument<UpdateAdvogadoDto> patch);
        Task<bool> RemoverAsync(int id);
    }
}
