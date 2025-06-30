using System;
using DemoSampleAPI.Auth.Helpers;
using DemoSampleAPI.Auth.Services;

namespace DemoSampleAPI.Auth;

public static class AuthModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        services.AddScoped<IAuthServices, AuthService>();
        services.AddSingleton<JwtTokenGenerator>();
        return services;
    }
}
