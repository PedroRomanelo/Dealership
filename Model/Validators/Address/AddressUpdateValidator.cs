using Dealership.Model.Request.Address;
using FluentValidation;

namespace Dealership.Model.Validators.Address;

public class AddressUpdateValidator : AbstractValidator<AddressUpdateRequestVM>
{
    public AddressUpdateValidator()
    {
        When(x => !string.IsNullOrWhiteSpace(x.Street), () => {
            RuleFor(x => x.Street)
            .MaximumLength(100).WithMessage("O campo rua não deve ter mais do que 100 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo rua."); ;
        });

        When(x => !string.IsNullOrWhiteSpace(x.Number), () => {
            RuleFor(x => x.Number)
            .MaximumLength(100).WithMessage("O campo número do endereço não deve ter mais do que 100 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo número do endereço."); ;
        });

        When(x => !string.IsNullOrWhiteSpace(x.City), () => 
        {
            RuleFor(x => x.City)
            .MaximumLength(100).WithMessage("O campo cidade não deve ter mais do que 100 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo cidade.");
        });

        When(x => !string.IsNullOrWhiteSpace(x.State), () =>
        {
            RuleFor(x => x.State)
            .Matches("^[A-Z]{2}$").WithMessage("Estado deve conter 2 letras maiúsculas (UF).")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo Estado.");
        });
    
    }
}
