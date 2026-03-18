using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IInsuranceRepository
{
    Task<int> InsertAsync(Insurance insurance);
    Task<bool> UpdateAsync(Insurance insurance);
    Task<IEnumerable<Insurance>> GetByModelAsync(int modelId);
    Task<Insurance?> GetByIdAsync(int id);
}
