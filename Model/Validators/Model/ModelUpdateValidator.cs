using FluentValidation;
using Dealership.Model.Request.Model;

namespace Dealership.Model.Validators.Model;

public class ModelUpdateValidator : AbstractValidator<ModelUpdateVM>
{
    public ModelUpdateValidator()
    {

        When(x => !string.IsNullOrWhiteSpace(x.Model), () => 
        {
             RuleFor(x => x.Model)
            .MaximumLength(50).WithMessage("O campo modelo deve ter no máximo 50 caracteres")
            .NotEmpty().WithMessage("O campo modelo não deve ser enviado vazio.");
        });

        When(x => !string.IsNullOrWhiteSpace(x.Brand), () =>
        {
            RuleFor(x => x.Brand)
            .MaximumLength(100).WithMessage("O campo marca deve ter no máximo 100 caracteres")
            .NotEmpty().WithMessage("O campo marca não deve ser enviado vazio.");
        });

    }
}
