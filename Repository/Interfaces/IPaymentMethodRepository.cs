using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IPaymentMethodRepository
{
    Task<int> CreateAsync(PaymentMethod paymentMethod);
    Task<bool> UpdateAsync(PaymentMethod paymentMethod);
    Task<bool> DeactivateAsync(int id);
    Task<bool> ReactivateAsync(int id);
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
    Task<PaymentMethod?> GetByIdAsync(int id);
}
