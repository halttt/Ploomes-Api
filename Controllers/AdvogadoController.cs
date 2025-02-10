using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Models;
using Ploomers_Advogados.Services;

namespace Ploomers_Advogados.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvogadoController : ControllerBase
    {
        private readonly IAdvogadoService _advogadoService;

        public AdvogadoController(IAdvogadoService advogadoService)
        {
            _advogadoService = advogadoService;
        }

        /// <summary>
        /// Cria um novo advogado.
        /// </summary>
        /// <param name="dto">Os dados necessários para criar um advogado.</param>
        /// <returns>O advogado recém-criado.</returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(Advogado), 201)]  // Resposta com o advogado recém-criado
        [ProducesResponseType(400)] // Resposta caso haja um erro de validação
        public async Task<IActionResult> Cadastrar([FromBody] CreateAdvogadoDto dto)
        {
            var advogado = await _advogadoService.CadastrarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = advogado.Id }, advogado);
        }

        /// <summary>
        /// Obtém os detalhes de um advogado pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do advogado.</param>
        /// <returns>Detalhes do advogado.</returns>
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(Advogado), 200)]  // Retorna os detalhes do advogado
        [ProducesResponseType(404)] // Caso o advogado não seja encontrado
        public async Task<IActionResult> ObterPorId(int id)
        {
            var advogado = await _advogadoService.ObterPorIdAsync(id);
            if (advogado == null) return NotFound();
            return Ok(advogado);
        }

        /// <summary>
        /// Obtém todos os advogados cadastrados.
        /// </summary>
        /// <returns>Uma lista de todos os advogados cadastrados.</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(IEnumerable<Advogado>), 200)]  // Retorna a lista de advogados
        public async Task<IActionResult> ObterTodos()
        {
            var advogados = await _advogadoService.ObterTodosAsync();
            return Ok(advogados);
        }

        /// <summary>
        /// Atualiza parcialmente os dados de um advogado.
        /// </summary>
        /// <param name="id">O ID do advogado a ser atualizado.</param>
        /// <param name="patch">O documento JSON Patch contendo as alterações.</param>
        /// <returns>Resultado da atualização.</returns>
        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(204)]  // Atualização bem-sucedida, sem conteúdo adicional
        [ProducesResponseType(400)]  // Caso o patch esteja inválido
        [ProducesResponseType(404)]  // Caso o advogado não seja encontrado
        public async Task<IActionResult> AtualizarParcial(int id, [FromBody] JsonPatchDocument<UpdateAdvogadoDto> patch)
        {
            if (patch == null)
            {
                return BadRequest("O documento de patch não pode ser nulo.");
            }

            var resultado = await _advogadoService.AtualizarAsync(id, patch);
            if (!resultado)
            {
                return NotFound($"Advogado com ID {id} não encontrado.");
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta um advogado pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do advogado a ser deletado.</param>
        /// <returns>Resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(204)]  // Exclusão bem-sucedida, sem conteúdo adicional
        [ProducesResponseType(404)]  // Caso o advogado não seja encontrado
        public async Task<IActionResult> Deletar(int id)
        {
            var advogadoExistente = await _advogadoService.ObterPorIdAsync(id);
            if (advogadoExistente == null)
            {
                return NotFound($"Advogado com ID {id} não encontrado.");
            }

            await _advogadoService.RemoverAsync(id);
            return NoContent(); // Indica que a exclusão foi bem-sucedida sem retornar conteúdo adicional
        }
    }
}
