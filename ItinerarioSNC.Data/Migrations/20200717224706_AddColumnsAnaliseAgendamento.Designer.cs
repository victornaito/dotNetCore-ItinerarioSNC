﻿// <auto-generated />
using System;
using ItinerarioSNC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItinerarioSNC.Infra.Data.Migrations
{
    [DbContext(typeof(MySqlServerContext))]
    [Migration("20200717224706_AddColumnsAnaliseAgendamento")]
    partial class AddColumnsAnaliseAgendamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ItinerarioSNC.Domain.Entities.AnaliseAgendamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Carro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacaoAgendamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeColaborador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PessoaFisicaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeAlocacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaFisicaId");

                    b.ToTable("AnaliseAgendamento","usuario");
                });

            modelBuilder.Entity("ItinerarioSNC.Domain.Entities.PessoaFisica", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CPF")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PessoaFisica","usuario");
                });

            modelBuilder.Entity("ItinerarioSNC.Domain.Entities.AnaliseAgendamento", b =>
                {
                    b.HasOne("ItinerarioSNC.Domain.Entities.PessoaFisica", "PessoaFisica")
                        .WithMany()
                        .HasForeignKey("PessoaFisicaId");
                });
#pragma warning restore 612, 618
        }
    }
}
