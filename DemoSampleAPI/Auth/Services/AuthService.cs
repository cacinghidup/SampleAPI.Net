using System;
using DemoSampleAPI.Auth.DTO;
using DemoSampleAPI.Auth.Helpers;

namespace DemoSampleAPI.Auth.Services;

public class AuthService : IAuthServices
{
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthService(JwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public string? Login(LoginRequest loginRequest)
    {
        if (loginRequest.UserName == "admin" && loginRequest.Password == "admin")
        {
            return _jwtTokenGenerator.GenerateToken(loginRequest.UserName);
        }

        return null;
    }
}
