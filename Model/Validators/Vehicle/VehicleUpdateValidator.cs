using FluentValidation;
using Dealership.Model.Request.Vehicle;

namespace Dealership.Model.Validators.Vehicle;

public class VehicleUpdateValidator : AbstractValidator<VehicleUpdateVM>
{
    public VehicleUpdateValidator()
    {
        When(x => !string.IsNullOrEmpty(x.LicensePlate), () =>
        {
            RuleFor( x => x.LicensePlate)
                .Length(7).WithMessage("A placa do carro deve ter exatamente 7 caracateres.")
                .Matches(@"[A-Z0-9]+$").WithMessage("A placa só aceita números e letras maiúsculas.");
        });

        When(x => x.ModelId.HasValue, () =>
        {
            RuleFor(x => x.ModelId)
                .GreaterThan(0).WithMessage("O Id do modelo deve ser maior que zero.");
        });

        When(x => x.Mileage.HasValue, () =>
        {
            RuleFor(x => x.Mileage)
                .PrecisionScale(2, 10, true).WithMessage("Máximo 2 casas decimais").WithMessage("Taxa diária deve ser decimal");
            //tentar negativo
        });

        When(x => x.DailyRate.HasValue, () =>
        {
            RuleFor(x => x.DailyRate)
                .PrecisionScale(2, 10, true).WithMessage("Máximo 2 casas decimais").WithMessage("Taxa diária deve ser decimal");
            //tentar negativo
        });
            
    }
}
