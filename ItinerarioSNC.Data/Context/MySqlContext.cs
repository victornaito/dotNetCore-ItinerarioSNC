using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Infra.Data.Mapping;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItinerarioSNC.Infra.Data.Context
{
    public class MySqlServerContext : DbContext
    {
        //DbSet<PessoaFisica> PessoaFisica { get; set; }
        //public MySqlContext(DbContextOptions options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost;Port=8080;Database=modelo;Uid=[USUARIO];Pwd=[SENHA]");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PessoaFisica>(new PessoaFisicaMapping().Configure);
        }

    }
}
