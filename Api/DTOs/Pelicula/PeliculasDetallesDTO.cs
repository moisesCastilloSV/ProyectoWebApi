namespace Api.DTOs.Pelicula
{
    public class PeliculasDetallesDTO :PeliculaDTO
    {

        public List<ActorPeliculaDetalleDTO> Actores { get; set; }
    }
}
