using System;
using DemoSampleAPI.User.Models;

namespace DemoSampleAPI.User.Services;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetUserByUsername(string username);
    string? RegisterUser(UserModel user);
}
