using Dealership.Model.Request.User;
using FluentValidation;

namespace Dealership.Model.Validators.User;

public class UserUpdateValidator :AbstractValidator<UserUpdateVM>
{
    public UserUpdateValidator()
    {
        When(x => !string.IsNullOrEmpty(x.Name), () => 
        { 
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo  não deve estar vazio.")
                .MaximumLength(100).WithMessage("O campo  deve ter no máximo 100 caracteres.")
                .Matches(@"[a-zA-Z]+$").WithMessage("O campo nome deve receber apenas letras.");
        });

        When(x => !string.IsNullOrEmpty(x.Document), () => 
        { 
            RuleFor(x => x.Document)
                .NotEmpty().WithMessage("O campo documento não deve estar vazio.")
                .Length(11).WithMessage("O campo documento deve ter exatamente 11 caracteres")
                .Matches(@"^\d+$").WithMessage("O campo documento deve receber apenas números");
        });

        When(x => !string.IsNullOrEmpty(x.Email), () => 
        { 
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo email não deve estar vazio.")
                .MaximumLength(100).WithMessage("O campo email deve ter no máximo 100 caracteres.")
                .EmailAddress().WithMessage("O campo deve ter o formato de email.");
        });

        When(x => !string.IsNullOrEmpty(x.PhoneNumber), () => 
        { 
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("O campo número de telefone não deve estar vazio.")
                .Length(11).WithMessage("O campo número de telefone deve ter exatamente 11 caracteres.")
                .Matches(@"^\d+$").WithMessage("O campo número de telefone deve receber apenas");
        });

        When(x => x.BirthDate.HasValue, () => 
        { 
            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now).WithMessage("A data deve ser anterior a data de hoje");
        });
    }
}
