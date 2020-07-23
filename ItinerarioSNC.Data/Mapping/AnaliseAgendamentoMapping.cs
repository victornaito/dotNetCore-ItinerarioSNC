using ItinerarioSNC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItinerarioSNC.Infra.Data.Mapping
{
    public class AnaliseAgendamentoMapping : IEntityTypeConfiguration<AnaliseAgendamento>
    {
        public void Configure(EntityTypeBuilder<AnaliseAgendamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Carro)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .IsRequired();

            builder.Property(x => x.DataCriacaoAgendamento)
                .IsRequired();

            builder.Property(x => x.Estado)
                .IsRequired();

            builder.Property(x => x.NomeColaborador)
                .IsRequired();

            builder.Property(x => x.Placa)
                .IsRequired();

            builder.Property(x => x.UnidadeAlocacao)
               .IsRequired();

            builder.ToTable("AnaliseAgendamento", "usuario");
        }
    }
}
