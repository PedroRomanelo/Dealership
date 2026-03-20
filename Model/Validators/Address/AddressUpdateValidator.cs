using Dealership.Model.Request.Address;
using FluentValidation;

namespace Dealership.Model.Validators.Address;

public class AddressUpdateValidator : AbstractValidator<AddressUpdateRequestVM>
{
    public AddressUpdateValidator()
    {
        When(x => !string.IsNullOrEmpty(x.Street), () => {
            RuleFor(x => x.Street)
            .MaximumLength(100).WithMessage("O campo rua não deve ter mais do que 100 caracteres.");
        });

        When(x => !string.IsNullOrEmpty(x.Number), () => {
            RuleFor(x => x.Number)
            .MaximumLength(100).WithMessage("O campo número do endereço não deve ter mais do que 100 caracteres.");
        });

        When(x => !string.IsNullOrEmpty(x.City), () => 
        {
            RuleFor(x => x.City)
            .MaximumLength(100).WithMessage("O campo cidade não deve ter mais do que 100 caracteres.");
        });

        When(x => !string.IsNullOrEmpty(x.State), () =>
        {
            RuleFor(x => x.State)
            .Length(2).WithMessage("Estado deve ter 2 letras (UF) !");
        });
    
    }
}
