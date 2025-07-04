using System;
using DemoSampleAPI.User.Models;

namespace DemoSampleAPI.User.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> SearchByUsername(string username);
    Task<int> CreateAsync(UserModel user);
    Task<bool> CheckUsername(string user);
}
