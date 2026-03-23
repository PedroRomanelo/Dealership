using Dealership.Model.Request.Insurance;
using FluentValidation;

namespace Dealership.Model.Validators.Insurance;
public class InsuranceCreateValidator : AbstractValidator<InsuranceCreateVM>
{
    public InsuranceCreateValidator() {
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("O limite de caracteres é 500 caracteres.");

        RuleFor(x => x.ModelId)
            .GreaterThan(0).WithMessage("O campo ID do modelo é obrigatório.");

        RuleFor(x => x.DailyRate)
            .GreaterThan(0).WithMessage("A taxa diária deve ser maior que zero.")
            .PrecisionScale(10, 2, true).WithMessage("Máximo 2 casas decimais.");
    }
}
