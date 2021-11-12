using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Models;

namespace Api.CTX
{
    public partial class ApiCTX : DbContext
    {
        private readonly IConfiguration configuration;

        public ApiCTX()
        {
            
        }

        public ApiCTX(DbContextOptions<ApiCTX> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Pelicula> Peliculas { get; set; } = null!;
        public virtual DbSet<PeliculaActore> PeliculaActores { get; set; } = null!;
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculaActore>(entity =>
            {
                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.PeliculaActores)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__PeliculaA__Actor__398D8EEE");

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.PeliculaActores)
                    .HasForeignKey(d => d.PeliculaId)
                    .HasConstraintName("FK__PeliculaA__Pelic__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
