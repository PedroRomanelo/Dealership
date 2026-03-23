using Dealership.Model.Entities;
using Dealership.Model.Request.PaymentMethod;
using FluentValidation;

namespace Dealership.Model.Validators.PaymentMethod;

public class PaymentMethodUpdateValidator : AbstractValidator<PaymentMethodUpdateVM>
{
    public PaymentMethodUpdateValidator() 
    {

        When(x => !string.IsNullOrWhiteSpace(x.Name), () => {
            RuleFor(x => x.Name)
            .MaximumLength(40).WithMessage("O campo de nome deve ter no máximo 40 caracteres.");
        });
            
        When(x => !string.IsNullOrWhiteSpace(x.Description), () =>
        {
            RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("O campo de descrição deve ter no máximo 500 caracteres.");
        });
    }
}
