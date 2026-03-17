using Dealership.Model.Entities;
using Dealership.Model.Request.PaymentMethod;
using Dealership.Model.Response.PaymentMethod;

namespace Dealership.Service.Interfaces;

public interface IPaymentMethodService
{
    Task<IEnumerable<PaymentMethodResponseVM>> GetAllAsync();
    Task<PaymentMethodResponseVM> CreateAsync(PaymentMethodCreateVM request);
    Task<bool> UpdateAsync(int id, PaymentMethodUpdateVM request);
    Task<bool> DeactivateAsync(int id);
}
