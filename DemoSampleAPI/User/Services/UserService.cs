using System;
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

    public string RegisterUser(UserModel user)
    {
        bool checkUser = _userRepository.CheckUsername(user.Username);
        if (!checkUser) return "Username Already Taken!";

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var createUser = _userRepository.CreateAsync(user);
        if (createUser.Result > 0) return "Create Account Success!";

        return "Can't create account at this time. Please try again later!";
    }
}
