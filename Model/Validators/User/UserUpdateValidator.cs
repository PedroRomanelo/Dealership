using Dealership.Model.Request.User;
using FluentValidation;

namespace Dealership.Model.Validators.User;

public class UserUpdateValidator :AbstractValidator<UserUpdateVM>
{
    public UserUpdateValidator()
    {
        When(x => !string.IsNullOrWhiteSpace(x.Name), () => 
        { 
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("O campo  deve ter no máximo 100 caracteres.")
                .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("O campo nome deve receber apenas letras.");
        });

        When(x => !string.IsNullOrWhiteSpace(x.Document), () => 
        { 
            RuleFor(x => x.Document)
                .Length(11).WithMessage("O campo documento deve ter exatamente 11 caracteres")
                .Matches(@"^\d{11}$").WithMessage("O campo documento deve receber apenas números");
        });

        When(x => !string.IsNullOrWhiteSpace(x.Email), () => 
        { 
            RuleFor(x => x.Email)
                .MaximumLength(100).WithMessage("O campo email deve ter no máximo 100 caracteres.")
                .EmailAddress().WithMessage("O campo deve ter o formato de email.");
        });

        When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber), () => 
        { 
            RuleFor(x => x.PhoneNumber)
                .Length(11).WithMessage("O campo número de telefone deve ter exatamente 11 caracteres.")
                .Matches(@"^\d{11}$").WithMessage("O campo número de telefone deve receber apenas números");
        });

        When(x => x.BirthDate.HasValue, () => 
        { 
            RuleFor(x => x.BirthDate)
                 .Must(date => date < DateTime.Now).WithMessage("A data deve ser anterior a data de hoje");
        });
    }
}
