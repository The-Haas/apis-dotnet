using FluentValidation;
using api_final.Services.DTOs;

namespace api_final.Validators
{
    public class TelefoneValidator : AbstractValidator<TelefoneRequestDTO>
    {
        public TelefoneValidator()
        {
            RuleFor(x => x.NumeroTelefone)
                .NotEmpty().WithMessage("O número do telefone é obrigatório.")
                .GreaterThan(0).WithMessage("O número do telefone deve ser maior que zero.");

            RuleFor(x => x.IdCliente)
                .GreaterThan(0).WithMessage("O Id do cliente deve ser maior que zero.");
        }
    }
}
