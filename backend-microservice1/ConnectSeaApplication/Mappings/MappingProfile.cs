using AutoMapper;
using ConnectSeaApplication.Dto;
using ConnectSeaRepository.Entities;

namespace ConnectSeaApplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EscalaDto, Escala>().ReverseMap();
            CreateMap<ManifestoDto, Manifesto>().ReverseMap();
            CreateMap<ManifestoEscalaDto, ManifestoEscala>().ReverseMap();
        }
    }
}