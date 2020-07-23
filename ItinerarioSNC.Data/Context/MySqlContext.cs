using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ItinerarioSNC.Infra.Data.Context
{
    public class MySqlServerContext : DbContext
    {
        public MySqlServerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PessoaFisica>(new PessoaFisicaMapping().Configure);
            modelBuilder.Entity<AnaliseAgendamento>(new AnaliseAgendamentoMapping().Configure);
        }

    }
}
