using System;

namespace ItinerarioSNC.Domain.Dtos
{
    public class PessoaFisicaDto
    {
        public int? Cpf { get; set; }
        public string SocialName { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Department { get; set; }
    }
}
