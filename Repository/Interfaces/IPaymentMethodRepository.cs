using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IPaymentMethodRepository
{
    Task<int> CreateAsync(PaymentMethod paymentMethod);
    Task<bool> UpdateAsync(PaymentMethod paymentMethod);
    Task<bool> DeactivateAsync(int ModelId);
    Task<bool> ReactivateAsync(int ModelId);
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
}
