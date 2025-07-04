using System;
using DemoSampleAPI.Helpers;
using DemoSampleAPI.User.DTO;
using DemoSampleAPI.User.Models;
using DemoSampleAPI.User.Repositories;

namespace DemoSampleAPI.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<UserModel>> GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService?> RegisterUser(RegisterRequest user)
    {
        var userModel = new UserModel()
        {
            Username = user.Username,
            Email = user.Email,
            CreateAt = DateTime.UtcNow,
            TelCode = user.TelCode,
            Telephone = user.Telephone,
            IsAdmin = false,
        };

        bool checkUser = await _userRepository.CheckUsername(userModel.Username);
        if (!checkUser) return BaseServiceResult.Bad("Username Already Taken!");

        userModel.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var createUser = await _userRepository.CreateAsync(userModel);
        if (createUser > 0) return BaseServiceResult.Ok("Create Account Success!");

        return BaseServiceResult.Error("Can't create account at this time. Please try again later!");
    }
}
