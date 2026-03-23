using Dealership.Model.Request.User;
using FluentValidation;

namespace Dealership.Model.Validators.User;

public class UserRegisterValidator : AbstractValidator<UserRegisterVM>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo nome não deve estar vazio.")
            .MaximumLength(100).WithMessage("O campo nome deve ter no máximo 100 caracteres.")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("O campo nome deve receber apenas letras.");

        RuleFor(x => x.Document)
            .NotEmpty().WithMessage("O campo documento não deve estar vazio.")
            .Length(11).WithMessage("O campo documento deve ter exatamente 11 caracteres")
            .Matches(@"^[0-9]{11}$").WithMessage("O campo documento deve receber apenas números");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O campo email não deve estar vazio.")
            .MaximumLength(100).WithMessage("O campo email deve ter no máximo 100 caracteres.")
            .EmailAddress().WithMessage("O campo deve ter o formato de email.");

        RuleFor(x => x.PhoneNumber)
            .Length(11).WithMessage("O campo número de telefone deve ter no exatamente 11 caracteres (com DDD). Números fixos não aceitos.")
            .Matches(@"^[0-9]{11}$").WithMessage("O campo número de telefone deve receber apenas");

        RuleFor(x => x.BirthDate)
            .Must(date => date < DateTime.Now).WithMessage("A data deve ser anterior a data de hoje");
    }
}