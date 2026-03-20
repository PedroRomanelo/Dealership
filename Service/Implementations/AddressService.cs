using Dealership.Model.Entities;
using Dealership.Model.Request.Address;
using Dealership.Model.Request.Admin;
using Dealership.Repository.Interfaces;

namespace Dealership.Service.Interfaces;

public class AddressService: IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<int?> CreateAsync(AddressCreateRequest request) 
    {
        var address = new UserAddresses
        {
            UserId = request.UserId,
            Street = request.Street,
            Number = request.Number,
            City = request.City,
            State = request.State,
            Status = true
        };

        return await _addressRepository.CreateAsync(address);
    }

    public async Task<bool> UpdateAsync(int id, AddressUpdateRequestVM request) 
    {
        var entity = await _addressRepository.GetByIdAsync(id);

        if (entity == null)
            throw new Exception("Endereço não localizado");

        if (request.Street != null )
            entity.Street = request.Street;

        if (request.Number != null )
            entity.Number = request.Number;

        if (request.City != null )
            entity.City = request.City;

        if (request.State != null )
            entity.State = request.State;

        return await _addressRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeactivateByUserIdAsync(int userId) 
    {
        return await _addressRepository.DeactivateByUserIdAsync(userId);
    }

}
