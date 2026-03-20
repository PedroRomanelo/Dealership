using Dealership.Model.Request.Address;
using FluentValidation;

namespace Dealership.Model.Validators.Address;

public class AddressCreateValidator : AbstractValidator<AddressCreateRequest>
{
    public AddressCreateValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("O campo Id do usuário não deve ser vazio")
            .GreaterThan(0).WithMessage("UserId inválido");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("O campo rua não deve ser vazio")
            .MaximumLength(100).WithMessage("O campo  não deve ter mais do que 100 caracteres.");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O campo número do endereço não deve ser vazio")
            .MaximumLength(100).WithMessage("O campo  não deve ter mais do que 100 caracteres.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("O campo Estado não deve ser vazio")
            .MaximumLength(100).WithMessage("O campo  não deve ter mais do que 100 caracteres.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("O campo Estado não deve ser vazio")
            .Length(2).WithMessage("Estado deve ter 2 letras (UF) !");
    }
};
