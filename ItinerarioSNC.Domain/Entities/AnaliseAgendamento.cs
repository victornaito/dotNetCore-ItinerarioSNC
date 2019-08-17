using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItinerarioSNC.Domain.Entities
{
    public class AnaliseAgendamento : BaseEntity
    {
        public AnaliseAgendamento()
        {
        }

        public AnaliseAgendamento(DateTime dataCriacaoAgendamento, PessoaFisica pessoaFisica)
        {
            DataCriacaoAgendamento = dataCriacaoAgendamento;
            PessoaFisica = pessoaFisica ;
        }

        public DateTime DataCriacaoAgendamento { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
    }
}