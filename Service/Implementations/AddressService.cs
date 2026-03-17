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

    public async Task<int> CreateAsync(AddressCreateRequest request) 
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

    public async Task<bool> UpdateAsync(int id, AddressUpdateRequest request) 
    {
        var address = new UserAddresses
        {
            Id = id,
            Street = request.Street,
            Number = request.Number,
            City = request.City,
            State = request.State,
            Status = true
        };

        return await _addressRepository.UpdateAsync(address);
    }

    public async Task<bool> DeactivateByUserIdAsync(int userId) 
    {
        return await _addressRepository.DeactivateByUserIdAsync(userId);
    }

}
