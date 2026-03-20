using Dealership.Model.Request.Insurance;
using FluentValidation;

namespace Dealership.Model.Validators.Insurance;

public class InsuranceUpdateValidator : AbstractValidator<InsuranceUpdateVM>
{
    public InsuranceUpdateValidator()
    {
        When(x => !string.IsNullOrEmpty(x.Description), () =>
        {
            RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("O limite de caracteres é 500 caracteres");
        });

        When(x => x.ModelId.HasValue, () =>
        {
            RuleFor(x => x.ModelId)
            .GreaterThan(0).WithMessage("O campo id do modelo é inválido")
            .NotEmpty().WithMessage("o campo id do modelo não pode estar vazio");

        });

        When(x => x.DailyRate.HasValue, () =>
        {
            RuleFor(x => x.DailyRate)
            .PrecisionScale(2, 10, true).WithMessage("Máximo 2 casas decimais").WithMessage("Taxa diária deve ser decimal")
            .NotEmpty().WithMessage("O campo de taxa diária não pode estar vazio.");
        });
    }
}
