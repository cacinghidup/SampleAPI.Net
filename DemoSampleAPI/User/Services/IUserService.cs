using System;
using DemoSampleAPI.Helpers;
using DemoSampleAPI.User.DTO;
using DemoSampleAPI.User.Models;

namespace DemoSampleAPI.User.Services;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetUserByUsername(string username);
    Task<ResultService?> RegisterUser(RegisterRequest user);
}
