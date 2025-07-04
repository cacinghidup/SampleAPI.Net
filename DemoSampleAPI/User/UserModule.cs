using System;
using DemoSampleAPI.User.Repositories;
using DemoSampleAPI.User.Services;

namespace DemoSampleAPI.User;

public static class UserModule
{
    public static IServiceCollection AddUserModule(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
