
using FluentValidation;
using api_final.DTOs;

namespace api_final.Validators
{
    public class ChamadoValidator : AbstractValidator<ChamadoRequestDTO>
    {
        public ChamadoValidator()
        {
            RuleFor(x => x.DescricaoChamado).NotEmpty().MaximumLength(3000);
            RuleFor(x => x.StatusChamado).NotEmpty().MaximumLength(20);
            RuleFor(x => x.TipoChamado).MaximumLength(50);
            RuleFor(x => x.DepartamentoChamado).MaximumLength(50);
        }
    }
}
