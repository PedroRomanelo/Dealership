using Dealership.Model.Request.Admin;
using FluentValidation;

namespace Dealership.Model.Validators.Admin;

public class AdminForgotPasswordValidator : AbstractValidator<AdminForgotPasswordRequestVM>
{
    public AdminForgotPasswordValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("O campo Login não pode ser vazio.");
    }
}
