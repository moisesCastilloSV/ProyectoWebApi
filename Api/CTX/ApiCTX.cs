using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Models;

namespace Api.CTX
{
    public partial class ApiCTX : DbContext
    {
        public ApiCTX()
        {
        }

        public ApiCTX(DbContextOptions<ApiCTX> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Pelicula> Peliculas { get; set; } = null!;
        public virtual DbSet<PeliculaActore> PeliculaActores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DMDUDB;Database=Api;Trusted_Connection=False; User ID=AdministradorDBA;Password=2021#ADMINUDB@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculaActore>(entity =>
            {
                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.PeliculaActoreActors)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__PeliculaA__Actor__2C3393D0");

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.PeliculaActorePeliculas)
                    .HasForeignKey(d => d.PeliculaId)
                    .HasConstraintName("FK__PeliculaA__Pelic__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
