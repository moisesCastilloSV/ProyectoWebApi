using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Table("Actor")]
    public partial class Actor: IId
    {
        public Actor()
        {
            PeliculaActoreActors = new HashSet<PeliculaActore>();
            PeliculaActorePeliculas = new HashSet<PeliculaActore>();
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
        public virtual ICollection<PeliculaActore> PeliculaActoreActors { get; set; }
        [InverseProperty(nameof(PeliculaActore.Pelicula))]
        public virtual ICollection<PeliculaActore> PeliculaActorePeliculas { get; set; }
    }
}
