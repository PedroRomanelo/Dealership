using FluentValidation;
using Dealership.Model.Request.Vehicle;

namespace Dealership.Model.Validators.Vehicle;

public class VehicleUpdateValidator : AbstractValidator<VehicleUpdateVM>
{
    public VehicleUpdateValidator()
    {
        When(x => !string.IsNullOrWhiteSpace(x.LicensePlate), () =>
        {
            RuleFor( x => x.LicensePlate)
                .Transform(x => x?.ToUpper())
                .Length(7).WithMessage("A placa do carro deve ter exatamente 7 caracateres.")
                .Matches(@"^[A-Z0-9]{7}$").WithMessage("A placa só aceita números e letras maiúsculas.");
        });

        When(x => x.ModelId.HasValue, () =>
        {
            RuleFor(x => x.ModelId)
                .GreaterThan(0).WithMessage("O Id do modelo deve ser maior que zero.");
        });

        When(x => x.Mileage.HasValue, () =>
        {
            RuleFor(x => x.Mileage)
                .GreaterThanOrEqualTo(0).WithMessage("Quilometragem não pode ser negativa.")
                .PrecisionScale(10, 2, true).WithMessage("Máximo 2 casas decimais");
        });

        When(x => x.DailyRate.HasValue, () =>
        {
            RuleFor(x => x.DailyRate)
                .GreaterThan(0).WithMessage("Taxa diária deve ser maior que zero.")
                .PrecisionScale(10, 2, true).WithMessage("Máximo 2 casas decimais");
        });
            
    }
}
