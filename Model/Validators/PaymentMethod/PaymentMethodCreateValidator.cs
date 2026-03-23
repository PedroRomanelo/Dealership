using Dealership.Model.Request.PaymentMethod;
using FluentValidation;

namespace Dealership.Model.Validators.PaymentMethod;

public class PaymentMethodCreateValidator : AbstractValidator<PaymentMethodCreateVM>
{
    public PaymentMethodCreateValidator() {
        RuleFor(x => x.Name)
            .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("O campo nome é obrigatório.")
            .MaximumLength(40).WithMessage("O campo nome deve ter no máximo 40 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo nome."); ;

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("O campo descrição deve ter no máximo 500 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo descrição."); ;
    }
}
