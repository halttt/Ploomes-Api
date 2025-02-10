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
    public class ProcessoController : ControllerBase
    {
        private readonly IProcessoService _processoService;

        public ProcessoController(IProcessoService processoService)
        {
            _processoService = processoService;
        }

        /// <summary>
        /// Cria um novo processo.
        /// </summary>
        /// <param name="dto">Os dados necessários para criar um processo.</param>
        /// <returns>O processo recém-criado.</returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(Processo), 201)]  // Resposta com o processo recém-criado
        [ProducesResponseType(400)] // Resposta caso haja um erro de validação
        public async Task<IActionResult> Cadastrar([FromBody] CreateProcessoDto dto)
        {
            var processo = await _processoService.CadastrarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = processo.Id }, processo);
        }

        /// <summary>
        /// Obtém os detalhes de um processo pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do processo.</param>
        /// <returns>Detalhes do processo.</returns>
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(Processo), 200)]  // Retorna os detalhes do processo
        [ProducesResponseType(404)] // Caso o processo não seja encontrado
        public async Task<IActionResult> ObterPorId(int id)
        {
            var processo = await _processoService.ObterPorIdAsync(id);
            if (processo == null) return NotFound();
            return Ok(processo);
        }

        /// <summary>
        /// Obtém todos os processos cadastrados.
        /// </summary>
        /// <returns>Uma lista de todos os processos cadastrados.</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(IEnumerable<Processo>), 200)]  // Retorna a lista de processos
        public async Task<IActionResult> ObterTodos()
        {
            var processos = await _processoService.ObterTodosAsync();
            return Ok(processos);
        }

        /// <summary>
        /// Atualiza parcialmente os dados de um processo.
        /// </summary>
        /// <param name="id">O ID do processo a ser atualizado.</param>
        /// <param name="patch">O documento JSON Patch contendo as alterações.</param>
        /// <returns>Resultado da atualização.</returns>
        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(204)]  // Atualização bem-sucedida, sem conteúdo adicional
        [ProducesResponseType(400)]  // Caso o patch esteja inválido
        [ProducesResponseType(404)]  // Caso o processo não seja encontrado
        public async Task<IActionResult> AtualizarParcial(int id, [FromBody] JsonPatchDocument<UpdateProcessoDto> patch)
        {
            if (patch == null)
            {
                return BadRequest("O documento de patch não pode ser nulo.");
            }

            var resultado = await _processoService.AtualizarAsync(id, patch);
            if (!resultado)
            {
                return NotFound($"Processo com ID {id} não encontrado.");
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta um processo pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do processo a ser deletado.</param>
        /// <returns>Resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(204)]  // Exclusão bem-sucedida, sem conteúdo adicional
        [ProducesResponseType(404)]  // Caso o processo não seja encontrado
        public async Task<IActionResult> Deletar(int id)
        {
            var processoExiste = await _processoService.ObterPorIdAsync(id);
            if (processoExiste == null)
            {
                return NotFound($"Processo com ID {id} não encontrado.");
            }

            await _processoService.RemoverAsync(id);
            return NoContent(); // Indica que a exclusão foi bem-sucedida sem retornar conteúdo adicional
        }
    }
}
