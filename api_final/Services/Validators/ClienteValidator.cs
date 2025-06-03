using FluentValidation;
using api_final.Services.DTOs;

namespace api_final.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteRequestDTO>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.RazaoSocialCliente)
                .NotEmpty().WithMessage("A razão social é obrigatória.")
                .MaximumLength(200).WithMessage("Máximo de 200 caracteres.");

            RuleFor(x => x.NomeFantasiaCliente)
                .NotEmpty().WithMessage("O nome fantasia é obrigatório.")
                .MaximumLength(200).WithMessage("Máximo de 200 caracteres.");

            RuleFor(x => x.CnpjCliente)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve ter exatamente 14 dígitos.");

            RuleFor(x => x.IeCliente)
                .NotEmpty().WithMessage("A IE é obrigatória.");

            RuleFor(x => x.EnderecoCliente)
                .MaximumLength(300).WithMessage("Máximo de 300 caracteres.");
        }
    }
}
