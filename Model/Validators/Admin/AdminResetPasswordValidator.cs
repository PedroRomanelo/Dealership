using Dealership.Model.Request.Admin;
using FluentValidation;

namespace Dealership.Model.Validators.Admin;

public class AdminResetPasswordValidator : AbstractValidator<AdminResetPasswordRequestVM>
{
    public AdminResetPasswordValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Campo de login é obrigatório.");

        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Campo Token é obrigatório.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Campo de nova senha é obrigatório.")
            .MinimumLength(8).WithMessage("A senha deve ter no minimo 8 caracteres")
            .MaximumLength(200).WithMessage("A senha deve ter no máximo 200 caracteres")
            .Matches(@"[a-z]").WithMessage("Deve ter ao menos uma letra minuscula.")
            .Matches(@"[A-Z]").WithMessage("Deve ter ao menos uma letra maiuscula.")
            .Matches(@"[0-9]").WithMessage("Deve ter ao menos um número.")
            .Matches(@"[!@#$%^&*(),.?""{}|<>]").WithMessage("Deve ter ao menos um caractere especial.");
    }
}

