using Dealership.Model.Request.Contract;
using FluentValidation;

namespace Dealership.Model.Validators.Contract;

public class ContractValidator : AbstractValidator<ContractRequestVM>
{
    public ContractValidator() {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("Campo Id do usuário é obrigatório.")

        RuleFor(x => x.ContractStartDate)
            .NotEmpty().WithMessage("Campo data de início do contrato é obrigatório.")
            .Must(date => date > DateTime.Now).WithMessage("Data deve ser futura.");

        RuleFor(x => x.ContractEndDate)
            .NotEmpty().WithMessage("Campo data final do contrato é obrigatório.")
            .GreaterThan(x => x.ContractStartDate).WithMessage("Data de fim deve ser maior que a data de início.");

        RuleFor(x => x.InsuranceId)
            .GreaterThan(0).WithMessage("Campo Id do seguro inválido.")
    .       When(x => x.InsuranceId.HasValue);

        RuleFor(x => x.PaymentMethodId)
            .GreaterThan(0).WithMessage("Campo Id do método de pagamento é obrigatório");
        
        RuleFor(x => x.VehicleId)
            .GreaterThan(0).WithMessage("Campo Id do veiculo é obrigatório");
    }
}
