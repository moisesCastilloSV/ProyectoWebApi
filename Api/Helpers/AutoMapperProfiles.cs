using Api.DTOs;
using Api.DTOs.Genero;
using Api.Models;
using AutoMapper;

namespace Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero,GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();
        }

    }
}
