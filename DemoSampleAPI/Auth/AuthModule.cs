using System;
using DemoSampleAPI.Auth.Helpers;
using DemoSampleAPI.Auth.Repositories;
using DemoSampleAPI.Auth.Services;

namespace DemoSampleAPI.Auth;

public static class AuthModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        services.AddScoped<IAuthServices, AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddSingleton<JwtTokenGenerator>();
        return services;
    }
}
