using ItinerarioSNC.Domain.Dtos;
using ItnerarioSNC.Generics.ApplicationCore.Base.Entities;
using System;

namespace ItinerarioSNC.Domain.Entities
{
    public class AnaliseAgendamento : BaseEntity
    {
        public string Estado { get; private set; }
        public string Carro { get; private set; }
        public string Cidade { get; private set; }
        public string NomeColaborador { get; private set; }
        public string Placa { get; private set; }
        public string UnidadeAlocacao { get; private set; }

        protected AnaliseAgendamento()
        {
        }

        public AnaliseAgendamento(DateTime dataCriacaoAgendamento)
        {
            DataCriacaoAgendamento = dataCriacaoAgendamento;
        }

        public AnaliseAgendamento(int id, string estado, string carro, string cidade, DateTime dataCriacaoAgendamento, string nomeColaborador, string placa, string unidadeAlocacao)
        {
            Id = id;
            this.Estado = estado;
            this.Carro = carro;
            this.Cidade = cidade;
            DataCriacaoAgendamento = dataCriacaoAgendamento;
            this.NomeColaborador = nomeColaborador;
            this.Placa = placa;
            this.UnidadeAlocacao = unidadeAlocacao;
        }

        public DateTime DataCriacaoAgendamento { get; private set; }
        public virtual PessoaFisica PessoaFisica { get; private set; }

        public static AnaliseAgendamento Instanciate(AnaliseAgendamentoDto dto) =>
            new AnaliseAgendamento((int)dto.Id, dto.Estado, dto.Carro, dto.Cidade, dto.DataCriacaoAgendamento, dto.NomeColaborador, dto.Placa, dto.UnidadeAlocacao);
    }
}