using FluentValidation;
using ItinerarioSNC.Domain.Entities;
using System;

namespace ItinerarioSNC.Service.Validators
{
    public class AnaliseAgendamentoValidator : AbstractValidator<AnaliseAgendamento>
    {
        public AnaliseAgendamentoValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.PessoaFisica)
                .NotEmpty().WithMessage("Cannot be Empty.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

            RuleFor(c => c.DataCriacaoAgendamento)
                .NotEmpty().WithMessage("Cannot be Empty.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");
        }
    }
}
