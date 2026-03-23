using Dealership.Model.Request.Model;
using FluentValidation;

namespace Dealership.Model.Validators.Model;

public class ModelRegisterValidator : AbstractValidator<ModelRegisterVM>
{
    public ModelRegisterValidator()
    {
        RuleFor(X => X.Model)
            .NotEmpty().WithMessage("O campo modelo é obrigatório.")
            .MaximumLength(50).WithMessage("O campo modelo deve ter no máximo 50 caracteres.")
            .Must(x => x == null ||(x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo Modelo.");

        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("O campo marca é obrigatório.")
            .MaximumLength(100).WithMessage("O campo marca deve ter no máximo 100 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo Marca.");
    }
}
