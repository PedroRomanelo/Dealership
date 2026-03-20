using Dealership.Model.Request.Insurance;
using FluentValidation;

namespace Dealership.Model.Validators.Insurance;
public class InsuranceCreateValidator : AbstractValidator<InsuranceCreateVM>
{
    public InsuranceCreateValidator() {
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("O limite de caracteres é 500 caracteres");

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("O campo ID do modelo é obrigatório.");

        RuleFor(x => x.DailyRate)
            .NotEmpty().WithMessage("O campo Taxa diária é obrigatório.")
            .PrecisionScale(2, 10, true).WithMessage("Máximo 2 casas decimais");
    }
}
