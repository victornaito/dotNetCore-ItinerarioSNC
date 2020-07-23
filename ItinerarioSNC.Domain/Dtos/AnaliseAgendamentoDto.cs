using ItinerarioSNC.Domain.Dtos.Base;
using System;

namespace ItinerarioSNC.Domain.Dtos
{
    public class AnaliseAgendamentoDto: BaseDto
    {
        public DateTime DataCriacaoAgendamento { get; set; } = DateTime.Now;
        public string Carro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string NomeColaborador { get; set; }
        public string Placa { get; set; }
        public string UnidadeAlocacao { get; set; }
    }
}
