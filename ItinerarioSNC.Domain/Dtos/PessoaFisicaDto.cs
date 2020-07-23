using System;

namespace ItinerarioSNC.Domain.Dtos
{
    public class PessoaFisicaDto
    {
        public string Cpf { get; set; }
        public string SocialName { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
