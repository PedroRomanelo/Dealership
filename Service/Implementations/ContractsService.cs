using Dealership.Model.Entities;
using Dealership.Model.Request.contract;
using Dealership.Model.Response.contract;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class contractService : IContractService
{
    private readonly IContractRepository _contractRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IInsuranceRepository _insuranceRepository;
    // Adicione IUserRepository e IPaymentMethodRepository conforme necessário

    public contractService(
        IContractRepository contractRepository,
        IVehicleRepository vehicleRepository,
        IInsuranceRepository insuranceRepository)
    {
        _contractRepository = contractRepository;
        _vehicleRepository = vehicleRepository;
        _insuranceRepository = insuranceRepository;
    }

    public async Task<ContractSimulationVM> SimulateContractAsync(ContractRequestVM request)
    {
        // 1. Busca os dados necessários (Simulação de busca real)
        // var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
        // var insurances = await _insuranceRepository.GetByModelAsync(vehicle.ModelId);

        // Exemplo simplificado de cálculo:
        int totalDays = (int)Math.Ceiling((request.EndDate - request.StartDate).TotalDays);
        if (totalDays <= 0) totalDays = 1;

        decimal vehicleDailyRate = 150.00m; // Substituir por vehicle.DailyRate
        decimal insuranceDailyRate = request.UseInsurance ? 85.50m : 0m; // Substituir pela busca real

        decimal vehicleCost = totalDays * vehicleDailyRate;
        decimal insuranceCost = totalDays * insuranceDailyRate;

        return new ContractSimulationVM
        {
            CustomerName = "Nome do Cliente Buscado", // Substituir por user.Name
            VehiclePlate = "ABC-1234", // Substituir por vehicle.LicensePlate
            PaymentMethod = "Cartão", // Substituir por payment.Name
            TotalDays = totalDays,
            VehicleCost = vehicleCost,
            InsuranceCost = insuranceCost,
            GrandTotal = vehicleCost + insuranceCost
        };
    }

    public async Task<int> CreateContractAsync(ContractRequestVM request)
    {
        // 1. Gera a simulação para obter os valores corretos
        var simulation = await SimulateContractAsync(request);

        // 2. Monta a entidade para salvar no banco
        var contract = new contract // Entidade a ser criada no Model.Entities
        {
            UserId = request.UserId,
            VehicleId = request.VehicleId,
            PaymentMethodId = request.PaymentMethodId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            UseInsurance = request.UseInsurance,
            TotalValue = simulation.GrandTotal,
            Status = 1 // Ativo
        };

        // 3. Salva e retorna o ID
        return await _contractRepository.CreateAsync(contract);
    }
}