using System;
using DemoSampleAPI.Auth.DTO;
using DemoSampleAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DemoSampleAPI.Auth.Services;

namespace DemoSampleAPI.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authService;

    public AuthController(IAuthServices authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest? loginRequest)
    {
        if (string.IsNullOrWhiteSpace(loginRequest?.Username) || string.IsNullOrWhiteSpace(loginRequest?.Password))
            return ApiResponse.BadRequest("Please Provide Username and Password!");

        var token = _authService.Login(loginRequest);
        if (token == null)
            return ApiResponse.BadRequest("Login Failed!");

        return ApiResponse.Ok(data: token);
    }

}
