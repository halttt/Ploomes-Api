using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Models;
using Ploomers_Advogados.Repository;

namespace Ploomers_Advogados.Services
{
    public class AdvogadoService : IAdvogadoService
    {
        private readonly IAdvogadoRepository _advogadoRepository;
        private readonly IMapper _mapper;

        public AdvogadoService(IAdvogadoRepository advogadoRepository, IMapper mapper)
        {
            _advogadoRepository = advogadoRepository;
            _mapper = mapper;
        }

        public async Task<ReadAdvogadoDto> CadastrarAsync(CreateAdvogadoDto dto)
        {
            var advogado = _mapper.Map<Advogado>(dto);
            await _advogadoRepository.AdicionarAsync(advogado);
            return _mapper.Map<ReadAdvogadoDto>(advogado);
        }

        public async Task<ReadAdvogadoDto> ObterPorIdAsync(int id)
        {
            var advogado = await _advogadoRepository.ObterPorIdAsync(id);
            return advogado != null ? _mapper.Map<ReadAdvogadoDto>(advogado) : null;
        }

        public async Task<IEnumerable<ReadAdvogadoDto>> ObterTodosAsync()
        {
            var advogados = await _advogadoRepository.ObterTodosAsync();
            return _mapper.Map<IEnumerable<ReadAdvogadoDto>>(advogados);
        }


        public async Task<bool> AtualizarAsync(int id, JsonPatchDocument<UpdateAdvogadoDto> patch)
        {
        var advogadoExistente = await _advogadoRepository.ObterPorIdAsync(id);
        if (advogadoExistente == null)
        {
            return false;
        }

        var advogadoParaAtualizar = _mapper.Map<UpdateAdvogadoDto>(advogadoExistente);
        patch.ApplyTo(advogadoParaAtualizar);

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(advogadoParaAtualizar);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(advogadoParaAtualizar, validationContext, validationResults, true);
        if (!isValid)
        {
            // Adicione erros ao ModelState ou retorne false
            return false;
        }

        _mapper.Map(advogadoParaAtualizar, advogadoExistente);
        await _advogadoRepository.AtualizarAsync(advogadoExistente);

        return true;

        }



    public async Task<bool> RemoverAsync(int id)
        {
            var advogadoExistente = await _advogadoRepository.ObterPorIdAsync(id);
            if (advogadoExistente == null) return false;

            await _advogadoRepository.RemoverAsync(advogadoExistente);
            return true;
        }
    }

}
