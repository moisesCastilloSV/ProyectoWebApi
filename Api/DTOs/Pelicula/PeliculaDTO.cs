 
namespace Api.DTOs.Pelicula
{
    public class PeliculaDTO
    {

        
        public int ID { get; set; }
        
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        
        public DateTime FechaEstreno { get; set; }
    }
}
