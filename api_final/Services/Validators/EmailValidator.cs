using FluentValidation;
using api_final.Services.DTOs;

namespace api_final.Validators
{
    public class EmailValidator : AbstractValidator<EmailRequestDTO>
    {
        public EmailValidator()
        {
            RuleFor(e => e.EnderecoEmail)
                .NotEmpty().WithMessage("O endereço de e-mail é obrigatório.")
                .EmailAddress().WithMessage("Endereço de e-mail inválido.");

            RuleFor(e => e.IdCliente)
                .GreaterThan(0).WithMessage("O ID do cliente deve ser maior que zero.");
        }
    }
}
