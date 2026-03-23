using Dealership.Model.Request.Insurance;
using FluentValidation;

namespace Dealership.Model.Validators.Insurance;

public class InsuranceUpdateValidator : AbstractValidator<InsuranceUpdateVM>
{
    public InsuranceUpdateValidator()
    {
        When(x => !string.IsNullOrWhiteSpace(x.Description), () =>
        {
            RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("O limite de caracteres é 500 caracteres");
        });

        When(x => x.ModelId.HasValue, () =>
        {
            RuleFor(x => x.ModelId)
            .GreaterThan(0).WithMessage("O campo id do modelo é inválido");

        });

        When(x => x.DailyRate.HasValue, () =>
        {
            RuleFor(x => x.DailyRate)
            .GreaterThan(0).WithMessage("Taxa diária deve ser maior que zero.")
            .PrecisionScale(10, 2, true).WithMessage("Máximo 2 casas decimais.")
        });
    }
}
