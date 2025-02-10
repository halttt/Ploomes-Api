using AutoMapper;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() {

            CreateMap<CreateUsuarioDto, Usuario>();

        }

    }
}
