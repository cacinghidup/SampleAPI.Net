using System;
using System.Threading.Tasks;
using DemoSampleAPI.Auth.DTO;
using DemoSampleAPI.Auth.Helpers;
using DemoSampleAPI.Auth.Repositories;
using DemoSampleAPI.Helpers;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace DemoSampleAPI.Auth.Services;

public class AuthService : IAuthServices
{
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly IAuthRepository _authRepository;

    public AuthService(JwtTokenGenerator jwtTokenGenerator, IAuthRepository authRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _authRepository = authRepository;
    }

    public async Task<ResultService<string>> Login(LoginRequest loginRequest)
    {
        var dataUser = await _authRepository.UserDataLogin(loginRequest);
        if (dataUser == null) return BaseServiceResult<string>.Bad( null , "Wrong Username or Password!");

        bool isValid = BCrypt.Net.BCrypt.Verify(loginRequest.Password, dataUser.Password);
        if (isValid)
        {
            return BaseServiceResult<string>.Ok(_jwtTokenGenerator.GenerateToken(loginRequest.Username));
        }

        return BaseServiceResult<string>.Error( null , "Wrong Username or Password!");
    }
}
