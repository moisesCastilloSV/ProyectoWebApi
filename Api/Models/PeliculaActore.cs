using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public partial class PeliculaActore  
    {
        [Key]
        public int ID { get; set; }
        public int? ActorId { get; set; }
        public int? PeliculaId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Personaje { get; set; } = null!;
        public int Orden { get; set; }

        [ForeignKey(nameof(ActorId))]
        [InverseProperty("PeliculaActores")]
        public virtual Actor? Actor { get; set; }
        [ForeignKey(nameof(PeliculaId))]
        [InverseProperty("PeliculaActores")]
        public virtual Pelicula? Pelicula { get; set; }
    }
}
