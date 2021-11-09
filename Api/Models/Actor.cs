using System;
using System.Collections.Generic;
 

namespace Api.Models
{
    public partial class Actor
    {
        public int ID { get; set; }
         
        public string Nombre { get; set; } = null!;

       
        public DateTime FechaNacimiento { get; set; }
        public string? Foto { get; set; }
    }
}
