using System;
using DemoSampleAPI.Auth.DTO;
using DemoSampleAPI.User.Models;

namespace DemoSampleAPI.Auth.Repositories;

public interface IAuthRepository
{
    Task<UserModel?> UserDataLogin(LoginRequest loginRequest);
}
