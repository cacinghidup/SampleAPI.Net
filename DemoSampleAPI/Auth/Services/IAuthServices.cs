using System;
using DemoSampleAPI.Auth.DTO;

namespace DemoSampleAPI.Auth.Services;

public interface IAuthServices
{
    string? Login(LoginRequest loginRequest);
}
