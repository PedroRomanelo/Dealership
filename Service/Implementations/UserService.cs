using Dealership.Model.Entities;
using Dealership.Model.Request.User;
using Dealership.Model.Response.User;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces; 

namespace Dealership.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponseVM?> GetByDocumentAsync(string document)
    {
        var user = await _userRepository.GetByDocumentAsync(document);
        if (user == null) return null;

        return MapToResponse(user);
    }

    public async Task<UserResponseVM?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null) return null;

        return MapToResponse(user);
    }

    public async Task<UserResponseVM> CreateAsync(UserRegisterVM request)
    {
        var docExist = await _userRepository.GetByDocumentAsync(request.Document);
        if (docExist != null)
        {
            throw new Exception("Documento já registrado");
        }

        var emailExist = await _userRepository.GetByEmailAsync(request.Email);
        if(emailExist != null)
        {
            throw new Exception("Email já registrado");
        }

        var newUser = new Users
        {
            Name = request.Name,
            Document = request.Document,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            BirthDate = request.BirthDate,
            Status = true
        };

        int newId = await _userRepository.CreateAsync(newUser);
        newUser.Id = newId;

        return MapToResponse(newUser);
    }

    public async Task<UserResponseVM> UpdateAsync(int id, UserUpdateVM request)
    {
        var entity = await _userRepository.GetByIdAsync(id);
        if (entity == null) 
            throw new Exception("Usuário não encontrado.");

        var userWithDoc = await _userRepository.GetByDocumentAsync(request.Document);
        if (userWithDoc != null && userWithDoc.Id != id)
        {
            throw new Exception("Documento já utilizado por outro usuário.");
        }

        var userWithEmail = await _userRepository.GetByEmailAsync(request.Email);
        if (userWithEmail != null && userWithEmail.Id != id)
        {
            throw new Exception("Email já utilizado por outro usuário.");
        }

        if(request.Name != null)
            entity.Name = request.Name;

        if(request.Document != null)
            entity.Document = request.Document;

        if(request.Email != null)
            entity.Email = request.Email;

        if(request.PhoneNumber != null)
            entity.PhoneNumber = request.PhoneNumber;

        if(request.BirthDate != null)
            entity.BirthDate = request.BirthDate;
        

        bool updated = await _userRepository.UpdateAsync(entity);
        if(!updated) {
            throw new Exception("User não encontrado, tente outro documento !");
        }

        return MapToResponse(entity);
    }
    public async Task<bool> DeactivateAsync(int id)
    {
        return await _userRepository.DeactivateAsync(id);
    }

    private UserResponseVM MapToResponse(Users user)
    {
        return new UserResponseVM
        {
            Name = user.Name,
            Document = user.Document,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            BirthDate = user.BirthDate
        };
    }
}