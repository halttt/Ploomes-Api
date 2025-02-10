using AutoMapper;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Profiles
{
    public class ProcessoProfile : Profile
    {
        public ProcessoProfile()
        {

            CreateMap<CreateProcessoDto, Processo>();
            CreateMap<UpdateProcessoDto, Processo>();
            CreateMap<Processo, UpdateProcessoDto>();
            CreateMap<Processo, ReadProcessoDto>();


        }
    }
}
