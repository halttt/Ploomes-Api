using Microsoft.AspNetCore.Mvc;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Services;

namespace Ploomers_Advogados.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService { get; set; }

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="createUsuarioDto">Os dados necessários para cadastrar um novo usuário.</param>
        /// <returns>Mensagem de sucesso.</returns>
        [HttpPost("cadastro")]
        [ProducesResponseType(200)]  // Resposta de sucesso
        [ProducesResponseType(400)]  // Caso os dados enviados sejam inválidos
        public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioDto createUsuarioDto)
        {
            await _usuarioService.Cadastrar(createUsuarioDto);
            return Ok("Usuário cadastrado");
        }

        /// <summary>
        /// Realiza o login de um usuário e retorna um token JWT.
        /// </summary>
        /// <param name="loginUsuarioDto">Os dados de login do usuário.</param>
        /// <returns>O token JWT do usuário.</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(string), 200)]  // Retorna o token JWT com o status 200
        [ProducesResponseType(400)]  // Caso os dados de login sejam inválidos
        [ProducesResponseType(401)]  // Caso o login falhe (credenciais inválidas)
        public async Task<IActionResult> Login(LoginUsuarioDto loginUsuarioDto)
        {
            var token = await _usuarioService.Login(loginUsuarioDto);
            return Ok(token);
        }

    }
}
