using System;

namespace DemoSampleAPI.Auth.DTO;

public class LoginRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
