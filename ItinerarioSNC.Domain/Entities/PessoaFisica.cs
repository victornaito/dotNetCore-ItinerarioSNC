using System;
using System.Collections.Generic;
using System.Text;

namespace ItinerarioSNC.Domain.Entities
{
    public class PessoaFisica : BaseEntity
    {
        public int? CPF { get; set; }
        public string SocialName { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Department { get; set; }
    }
}
