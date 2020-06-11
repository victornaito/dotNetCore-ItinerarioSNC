using System;

namespace ItinerarioSNC.Domain.Dtos
{
    public class AnaliseAgendamentoDto
    {
        public DateTime DataCriacaoAgendamento { get; set; }
        public PessoaFisicaDto PessoaFisica { get; set; }
    }
}
