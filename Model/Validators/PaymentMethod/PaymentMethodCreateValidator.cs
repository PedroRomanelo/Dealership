using Dealership.Model.Request.PaymentMethod;
using FluentValidation;

namespace Dealership.Model.Validators.PaymentMethod;

public class PaymentMethodCreateValidator : AbstractValidator<PaymentMethodCreateVM>
{
    public PaymentMethodCreateValidator() {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo nome é obrigatório.")
            .MaximumLength(40).WithMessage("O campo nome deve ter no máximo 40 caracteres.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("O campo descrição deve ter no máximo 500 caracteres.");
    }
}
