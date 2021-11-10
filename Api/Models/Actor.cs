using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Table("Actor")]
    public partial class Actor 
    {
        public Actor()
        {
            PeliculaActores = new HashSet<PeliculaActore>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime FechaNacimiento { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? Foto { get; set; }

        [InverseProperty(nameof(PeliculaActore.Actor))]
        public virtual ICollection<PeliculaActore> PeliculaActores { get; set; }
    }
}
