using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Table("Genero")]
    public partial class Genero : IId
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
    }
}
