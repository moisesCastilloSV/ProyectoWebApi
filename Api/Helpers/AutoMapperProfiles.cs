 
using Api.DTOs.Actor;
using Api.DTOs.Genero;
using Api.DTOs.Pelicula;
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

            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<ActorPatchDTO,Actor>().ReverseMap();

            CreateMap<Pelicula, PeliculaDTO>().ReverseMap();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(pelicula => pelicula.PeliculaActores, opciones => opciones.MapFrom(MapActoresPeliculas));


            CreateMap<Pelicula, PeliculasDetallesDTO>()
                .ForMember(x => x.Actores, options => options.MapFrom(MapActorPeliculaDetalle));
        }

        private List<PeliculaActore> MapActoresPeliculas(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        {
            var result= new List<PeliculaActore>();
            if (peliculaCreacionDTO.Actors == null) { return result; }

            foreach (var actor in peliculaCreacionDTO.Actors)
            {
                result.Add(new PeliculaActore() { ActorId = actor.ActorId,Personaje=actor.Personaje ,Orden=actor.orden});
            }
            return result;
        }

        private List<ActorPeliculaDetalleDTO> MapActorPeliculaDetalle(Pelicula pelicula,  PeliculasDetallesDTO  peliculasDetallesDTO)
        {
            var result = new List<ActorPeliculaDetalleDTO>();
            if (pelicula.PeliculaActores == null) { return result; }

            foreach (var actor in pelicula.PeliculaActores)
            {
                result.Add(new ActorPeliculaDetalleDTO() { ActorId = (int)actor.ActorId, Personaje = actor.Personaje, Nombre = actor.Actor.Nombre });
            }
            return result;
        }

    }
}
