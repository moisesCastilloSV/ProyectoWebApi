using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Actor
{
    public class ActorPatchDTO
    {

        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
