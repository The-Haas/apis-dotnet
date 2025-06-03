using FluentValidation;
using api_final.DTOs;

namespace api_final.Validators
{
    public class ResponsavelValidator : AbstractValidator<ResponsavelRequestDTO>
    {
        public ResponsavelValidator()
        {
            RuleFor(x => x.NomeResponsavel)
                .NotEmpty().WithMessage("O nome do responsável é obrigatório.")
                .MaximumLength(200).WithMessage("O nome deve ter no máximo 200 caracteres.");
        }
    }
}
