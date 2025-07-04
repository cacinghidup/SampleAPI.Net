using System;
using DemoSampleAPI.Interfaces;
using DemoSampleAPI.User.DTO;
using DemoSampleAPI.User.Models;
using DemoSampleAPI.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoSampleAPI.User.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> UserRegister([FromBody] RegisterRequest user)
    {
        var register = await _userService.RegisterUser(user);
        return register!.StatusCode switch
        {
            200 => ApiResponse.Ok(register.Message),
            400 => ApiResponse.BadRequest(register.Message),
            _ => ApiResponse.ServerError(register.Message)
        };
    }
}
