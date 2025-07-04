using System;
using DemoSampleAPI.Auth.DTO;
using DemoSampleAPI.Helpers;

namespace DemoSampleAPI.Auth.Services;

public interface IAuthServices
{
    Task<ResultService<string>> Login(LoginRequest loginRequest);
}
