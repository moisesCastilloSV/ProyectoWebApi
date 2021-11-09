﻿using System;
using System.Collections.Generic;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Genero> Generos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DMDUDB;Database=Api;Trusted_Connection=False; User ID=AdministradorDBA;Password=2021#ADMINUDB@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
