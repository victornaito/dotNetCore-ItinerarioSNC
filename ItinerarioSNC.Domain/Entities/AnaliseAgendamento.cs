using ItnerarioSNC.Generics.ApplicationCore.Base.Entities;
using System;

namespace ItinerarioSNC.Domain.Entities
{
    public class AnaliseAgendamento : BaseEntity
    {
        public AnaliseAgendamento()
        {
        }

        public AnaliseAgendamento(DateTime dataCriacaoAgendamento)
        {
            DataCriacaoAgendamento = dataCriacaoAgendamento;
        }

        public DateTime DataCriacaoAgendamento { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
    }
}