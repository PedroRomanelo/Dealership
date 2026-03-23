using Dealership.Model.Entities;
using Dealership.Model.Request.PaymentMethod;
using Dealership.Model.Response.PaymentMethod;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }

    public async Task<PaymentMethodResponseVM> CreateAsync(PaymentMethodCreateVM request)
    {
        var entity = new PaymentMethod
        {
            Name = request.Name,
            Description = request.Description,
        };

        entity.Id = await _paymentMethodRepository.CreateAsync(entity);

        return new PaymentMethodResponseVM { Name = entity.Name, Description = entity.Description };
    }

    public async Task<IEnumerable<PaymentMethodResponseVM>> GetAllAsync()
    {
        var methods = await _paymentMethodRepository.GetAllAsync();
        return methods.Select(m => new PaymentMethodResponseVM
        {
            Name = m.Name,
            Description = m.Description
        });
    }

    public async Task<bool> UpdateAsync(int id, PaymentMethodUpdateVM request)
    {
        var entity = await _paymentMethodRepository.GetByIdAsync(id);
        if (entity == null)
            throw new Exception("Id não encontrado");

        if (request.Description != null)
            entity.Description = request.Description;

        if (request.Name != null)
            entity.Name = request.Name;

        return await _paymentMethodRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        return await _paymentMethodRepository.DeactivateAsync(id);
    }
}
