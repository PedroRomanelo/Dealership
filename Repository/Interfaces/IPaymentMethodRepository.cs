using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IPaymentMethodRepository
{
    Task<int> CreateAsync(PaymentMethod paymentMethod);
    Task<bool> UpdateAsync(PaymentMethod paymentMethod);
    Task<int> DeactivateAsync(int ModelId);
    Task<int> ReactivateAsync(int ModelId);
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
}
