using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Actor
{
    public class ActorCreacionDTO
    {
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public DateTime FechaNacimiento { get; set; }

        //public IFormFile Foto { get; set; }
    }
}
