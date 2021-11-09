namespace Api.DTOs.Actor
{
    public class ActorDTO
    {

        public int ID { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? Foto { get; set; }
    }
}
