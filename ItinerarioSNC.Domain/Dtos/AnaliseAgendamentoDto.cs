using ItinerarioSNC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItinerarioSNC.Domain.Dtos
{
    public class AnaliseAgendamentoDto
    {
        public DateTime DataCriacaoAgendamento { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
    }
}
