using API.DTO;
using AutoMapper;
using Data.Models;

namespace API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
