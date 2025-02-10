using Ploomers_Advogados.Data.Dtos;

namespace Ploomers_Advogados.Services
{
    public interface IUsuarioService
    {
        Task Cadastrar(CreateUsuarioDto createUsuarioDto);

        Task<string> Login(LoginUsuarioDto loginUsuarioDto);

    }
}
