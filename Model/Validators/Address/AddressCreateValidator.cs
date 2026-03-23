using Dealership.Model.Request.Address;
using FluentValidation;

namespace Dealership.Model.Validators.Address;

public class AddressCreateValidator : AbstractValidator<AddressCreateRequest>
{
    public AddressCreateValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("O campo Id do usuário não deve ser vazio");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("O campo rua não deve ser vazio")
            .MaximumLength(100).WithMessage("O campo rua não deve ter mais do que 100 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo rua.");

        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("O campo número do endereço não deve ser vazio")
            .MaximumLength(100).WithMessage("O campo número do endereço não deve ter mais do que 100 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo número do endereço."); ;

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("O campo Estado não deve ser vazio")
            .MaximumLength(100).WithMessage("O campo cidade não deve ter mais do que 100 caracteres.")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo cidade.");

        RuleFor(x => x.State)
            .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("O campo Estado não deve ser vazio")
            .Matches("^[A-Z]{2}$").WithMessage("Estado deve conter 2 letras maiúsculas (UF).")
            .Must(x => x == null || (x.Trim() == x && !x.Contains("  "))).WithMessage("Não são permitidos espaços no início, no fim ou espaços duplos. Refaça o campo Estado.");
    }
};
