
// Classe que valida os dados recebidos no ChamadoRequestDTO usando FluentValidation.
// Garante que os campos obrigatórios estejam preenchidos e que os textos não ultrapassem o tamanho máximo.
using FluentValidation;
using api_final.DTOs;

namespace api_final.Validators
{
    public class ChamadoValidator : AbstractValidator<ChamadoRequestDTO>
    {
        public ChamadoValidator()
        {
            // Valida que DescricaoChamado não pode estar vazio e pode ter até 3000 caracteres
            RuleFor(x => x.DescricaoChamado).NotEmpty().MaximumLength(3000);

            // Valida que StatusChamado não pode estar vazio e pode ter até 20 caracteres
            RuleFor(x => x.StatusChamado).NotEmpty().MaximumLength(20);

            // Valida que TipoChamado pode ser nulo, mas se informado, deve ter no máximo 50 caracteres
            RuleFor(x => x.TipoChamado).MaximumLength(50);

            // Valida que DepartamentoChamado pode ser nulo, mas se informado, deve ter no máximo 50 caracteres
            RuleFor(x => x.DepartamentoChamado).MaximumLength(50);
        }
    }
}
