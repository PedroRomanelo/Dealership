using Dealership.Model.Request.Vehicle;
using FluentValidation;

namespace Dealership.Model.Validators.Vehicle;

public class VehicleCreateValidator : AbstractValidator<VehicleCreateVM>
{
    public VehicleCreateValidator()
    {
        RuleFor(x => x.LicensePlate)
            .NotEmpty().WithMessage("O campo de placa não deve estar vazio.")
            .Length(7).WithMessage("O campo de placa deve ter exatamente 7 caracteres.")
            .Matches(@"A-Z0-9+$").WithMessage("O campo da placa só aceita números e letras maiúsculas.");

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("O campo do id do modelo não pode estar vazio.");

        RuleFor(x => x.Mileage)
            .NotEmpty().WithMessage("O campo de quilometragem não pode estar vazio.")
            .PrecisionScale(2, 10, true).WithMessage("Máximo 2 casas decimais.");

        RuleFor(x => x.DailyRate)
            .NotEmpty().WithMessage("O campo de taxa diária não pode estar vazio.")
            .PrecisionScale(2, 10, true).WithMessage("Máximo 2 casas decimais.");


    }
}
