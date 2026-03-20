using Dealership.Model.Request.Contract;
using FluentValidation;

namespace Dealership.Model.Validators.Contract;

public class ContractValidator : AbstractValidator<ContractRequestVM>
{
    public ContractValidator() {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Campo Id do usuário é obrigatório");

        RuleFor(x => x.ContractStartDate)
            .NotEmpty().WithMessage("Campo data de inicio do contrato é obrigatório")
            .GreaterThan(DateTime.Now).WithMessage("Data deve ser futura");

        RuleFor(x => x.ContractEndDate)
            .NotEmpty().WithMessage("Campo data final do contrato é obrigatório")
            .GreaterThan(x => x.ContractStartDate).WithMessage("Data de fim deve ser maior que a data de inicio");
        
        RuleFor(x => x.InsuranceId)
            .NotNull().WithMessage("Campo Id do seguro não pode ser nulo.");
        
        RuleFor(x => x.PaymentMethodId)
            .NotEmpty().WithMessage("Campo Id do método de pagamento é obrigatório");
        
        RuleFor(x => x.VehicleId)
            .NotEmpty().WithMessage("Campo Id do veiculo é obrigatório");
    }
}
