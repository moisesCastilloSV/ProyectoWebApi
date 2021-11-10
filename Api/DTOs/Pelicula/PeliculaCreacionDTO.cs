using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Pelicula
{
    public class PeliculaCreacionDTO
    {


        [StringLength(maximumLength: 250)]
        [Required]
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }

        public DateTime FechaEstreno { get; set; }
       
        public List<ActorPeliculasCreacionDTO> Actors { get; set; }

        //public IFormFile Poster { get; set; }
    }
}
