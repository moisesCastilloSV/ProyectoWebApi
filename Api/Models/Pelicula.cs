using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Table("Pelicula")]
    public partial class Pelicula:IId
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaEstreno { get; set; }
    }
}
