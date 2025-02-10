using AutoMapper;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Profiles
{
    public class AdvogadoProfile : Profile
    {
        public AdvogadoProfile() {

            CreateMap<CreateAdvogadoDto, Advogado>();
            CreateMap<UpdateAdvogadoDto, Advogado>();
            CreateMap<Advogado, UpdateAdvogadoDto > ();
            CreateMap<Advogado, ReadAdvogadoDto>();
            CreateMap<Processo, ReadProcessoDto>();



        }
    }
}
