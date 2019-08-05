using ItinerarioSNC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItinerarioSNC.Infra.Data.Mapping
{
    public class PessoaFisicaMapping : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable("PessoaFisica", "usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Birthday)
                .IsRequired();

            builder.Property(x => x.CPF)
                .IsRequired();

            builder.Property(x => x.Department)
                .IsRequired();
        }
    }
}
