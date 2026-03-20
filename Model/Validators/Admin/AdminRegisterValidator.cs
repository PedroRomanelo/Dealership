using Dealership.Model.Request.Admin;
using FluentValidation;

namespace Dealership.Model.Validators.Admin;
public class AdminRegisterValidator : AbstractValidator<AdminRegisterVM>
{
    public AdminRegisterValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login é obrigatório")
            .MinimumLength(4).WithMessage("Login deve ter no minimo 4 caracteres")
            .MaximumLength(50).WithMessage("Login Deve ter no máximo 100 caracteres");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória")
            .MinimumLength(8).WithMessage("A senha deve ter no minimo 8 caracteres")
            .MaximumLength(200).WithMessage("A senha deve ter no máximo 200 caracteres")
            .Matches(@"[a-z]").WithMessage("Deve ter ao menos uma letra minuscula.")
            .Matches(@"[A-Z]").WithMessage("Deve ter ao menos uma letra maiuscula.")
            .Matches(@"[0-9]").WithMessage("Deve ter ao menos um número.")
            .Matches(@"[!@#$%^&*(),.?""{}|<>]").WithMessage("Deve ter ao menos um caractere especial.");

        RuleFor(x => x.Roles)
        .IsInEnum().WithMessage("Função inválida");
    }
}
