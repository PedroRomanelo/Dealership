using Dealership.Model.Request.Vehicle;
using FluentValidation;

namespace Dealership.Model.Validators.Vehicle;

public class VehicleCreateValidator : AbstractValidator<VehicleCreateVM>
{
    public VehicleCreateValidator()
    {
        RuleFor(x => x.LicensePlate)
            .Transform(x => x?.ToUpper())
            .NotEmpty().WithMessage("O campo de placa não deve estar vazio.")
            .Length(7).WithMessage("O campo de placa deve ter exatamente 7 caracteres.")
            .Matches(@"^[A-Z0-9]{7}$").WithMessage("O campo da placa só aceita números e letras maiúsculas.");

        RuleFor(x => x.ModelId)
            .GreaterThan(0).WithMessage("O campo do id do modelo não pode estar vazio.");

        RuleFor(x => x.Mileage)
            .NotEmpty().WithMessage("O campo de quilometragem não pode estar vazio.")
            .GreaterThanOrEqualTo(0).WithMessage("Quilometragem não pode ser negativa.")
            .PrecisionScale(10, 2, true).WithMessage("Máximo 2 casas decimais.");

        RuleFor(x => x.DailyRate)
            .GreaterThan(0).WithMessage("O campo de taxa diária não pode estar vazio.")
            .PrecisionScale(10, 2, true).WithMessage("Máximo 2 casas decimais.");
    }
}
