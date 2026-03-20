using Dealership.Model.Request.Admin;
using FluentValidation;

namespace Dealership.Model.Validators.Admin;

public class AdminLoginValidator : AbstractValidator<AdminLoginVM>
{
    public AdminLoginValidator()
    {    
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("O campo Login não pode ser vazio.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("O campo Senha não pode ser vazio."); 
    }
}