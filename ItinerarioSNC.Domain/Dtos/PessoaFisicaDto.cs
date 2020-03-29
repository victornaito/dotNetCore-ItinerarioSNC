using System;

namespace ItinerarioSNC.Domain.Dtos
{
    public class PessoaFisicaDto
    {
        public int? CPF { get; private set; }
        public string SocialName { get; private set; }
        public string FullName { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string Department { get; private set; }
    }
}
