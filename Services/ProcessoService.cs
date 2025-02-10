using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Models;
using Ploomers_Advogados.Repository;
using System.ComponentModel.DataAnnotations;

namespace Ploomers_Advogados.Services
{
    public class ProcessoService : IProcessoService
    {
        private readonly IProcessoRepository _processoRepository;
        private readonly IMapper _mapper;

        public ProcessoService(IProcessoRepository processoRepository, IMapper mapper)
        {
            _processoRepository = processoRepository;
            _mapper = mapper;
        }

        public async Task<ReadProcessoDto> CadastrarAsync(CreateProcessoDto dto)
        {
            var processo = _mapper.Map<Processo>(dto);
            await _processoRepository.AdicionarAsync(processo);
            return _mapper.Map<ReadProcessoDto>(processo);
        }

        public async Task<ReadProcessoDto> ObterPorIdAsync(int id)
        {
            var processo = await _processoRepository.ObterPorIdAsync(id);
            return processo != null ? _mapper.Map<ReadProcessoDto>(processo) : null;
        }

        public async Task<IEnumerable<ReadProcessoDto>> ObterTodosAsync()
        {
            var processo = await _processoRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<ReadProcessoDto>>(processo);
        }


        public async Task<bool> AtualizarAsync(int id, JsonPatchDocument<UpdateProcessoDto> patch)
        {
            var processoExiste = await _processoRepository.ObterPorIdAsync(id);
            if (processoExiste == null)
            {
                return false;
            }

            var processoParaAtualizar = _mapper.Map<UpdateProcessoDto>(processoExiste);
            patch.ApplyTo(processoParaAtualizar);

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(processoParaAtualizar);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(processoParaAtualizar, validationContext, validationResults, true);
            if (!isValid)
            {
                // Adicione erros ao ModelState ou retorne false
                return false;
            }

            _mapper.Map(processoParaAtualizar, processoExiste);
            await _processoRepository.AtualizarAsync(processoExiste);

            return true;

        }



        public async Task<bool> RemoverAsync(int id)
        {
            var processoExiste = await _processoRepository.ObterPorIdAsync(id);
            if (processoExiste == null) return false;

            await _processoRepository.RemoverAsync(processoExiste);
            return true;
        }
    }

}
