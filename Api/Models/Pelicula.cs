using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Table("Pelicula")]
    public partial class Pelicula  
    {
        public Pelicula()
        {
            //PeliculaActores = new HashSet<PeliculaActore>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaEstreno { get; set; }

        [InverseProperty(nameof(PeliculaActore.Pelicula))]
        //public virtual ICollection<PeliculaActore> PeliculaActores { get; set; }
        public List<PeliculaActore> PeliculaActores { get; set; }
    }
}
