namespace Api.DTOs.Pelicula
{
    public class PeliculaCreacionDTO
    {

        public int ID { get; set; }

        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }

        public DateTime FechaEstreno { get; set; }

        //public IFormFile Poster { get; set; }
    }
}
