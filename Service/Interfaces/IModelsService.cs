namespace Dealership.Service.Interfaces;

public interface IModelsService
{
    Task() SearchAsync(string brand, string model);
    Task() CreateAsync(CreateModelRequest request);
    Task() UpdateAsync(int id, UpdateModelRequest request);
    Task() DeactivateAsync(int id);
}
