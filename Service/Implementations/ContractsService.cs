using Dealership.Model.Entities;
using Dealership.Model.Request.Contract;
using Dealership.Model.Response.Contract;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class ContractsService : IContractsService
{
    private readonly IContractRepository _contractRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public ContractsService(
        IContractRepository contractRepository,
        IVehicleRepository vehicleRepository,
        IInsuranceRepository insuranceRepository,
        IUserRepository userRepository,
        IPaymentMethodRepository paymentMethodRepository)
    {
        _contractRepository = contractRepository;
        _vehicleRepository = vehicleRepository;
        _insuranceRepository = insuranceRepository;
        _userRepository = userRepository;
        _paymentMethodRepository = paymentMethodRepository;
    }

    public async Task<ContractResponseVM> ViewContractAsync(ContractRequestVM request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new Exception("Usuário não encontrado.");

        var paymentMethod = await _paymentMethodRepository.GetByIdAsync(request.PaymentMethodId)
            ?? throw new Exception("Meio de pagamento não encontrado.");

        var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId)
            ?? throw new Exception("Veículo não encontrado.");

        decimal insuranceRate = 0;


        if (request.InsuranceId > 0)
        {
            var insurance = await _insuranceRepository.GetByIdAsync(request.InsuranceId)
                ?? throw new Exception("Seguro não encontrado.");

            insuranceRate = insurance.DailyRate;
        }

        int days = (request.ContractEndDate - request.ContractStartDate).Days;
        days = days > 0 ? days : 1;

        decimal totalPrice = (vehicle.DailyRate + insuranceRate) * days;

        return new ContractResponseVM
        {
            UserId = request.UserId,
            VehicleId = request.VehicleId,
            ContractStartDate = request.ContractStartDate,
            ContractEndDate = request.ContractEndDate,
            InsuranceId = request.InsuranceId,
            PaymentMethodId = request.PaymentMethodId,
            TotalPrice = totalPrice
        };
    }

    public async Task<int> CreateContractAsync(ContractRequestVM request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new Exception("Usuário não encontrado.");

        var paymentMethod = await _paymentMethodRepository.GetByIdAsync(request.PaymentMethodId)
            ?? throw new Exception("Meio de pagamento não encontrado.");

        var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId)
            ?? throw new Exception("Veículo não encontrado.");

        decimal insuranceRate = 0;

        if (request.InsuranceId > 0)
        {
            var insurance = await _insuranceRepository.GetByIdAsync(request.InsuranceId)
                ?? throw new Exception("Seguro não encontrado.");

            insuranceRate = insurance.DailyRate;
        }

        int days = (request.ContractEndDate - request.ContractStartDate).Days;
        days = days > 0 ? days : 1;

        decimal totalPrice = (vehicle.DailyRate + insuranceRate) * days;

        var contract = new Contracts
        {
            ContractNumber = Guid.NewGuid().ToString("N").ToUpper(),
            UserId = request.UserId,
            VehicleId = request.VehicleId,
            ContractDate = DateTime.UtcNow,
            ContractStartDate = request.ContractStartDate,
            ContractEndDate = request.ContractEndDate,
            InsuranceId = request.InsuranceId,
            TotalPrice = totalPrice,
            PaymentMethodId = request.PaymentMethodId
        };

        return await _contractRepository.InsertAsync(contract);
    }
}