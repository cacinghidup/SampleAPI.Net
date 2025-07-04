using System;
using Dapper;
using DemoSampleAPI.Auth.DTO;
using DemoSampleAPI.Helpers.DbConnection.Services;
using DemoSampleAPI.User.Models;

namespace DemoSampleAPI.Auth.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public AuthRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<UserModel?> UserDataLogin(LoginRequest loginRequest)
    {
        using var conn = _dbConnectionFactory.CreateConnection();
        var sql = @"SELECT *, PasswordHash as Password FROM Users u WHERE u.Username = @Username";
        var user = await conn.QueryFirstOrDefaultAsync<UserModel>(sql, new { loginRequest.Username });
        return user;
    }
}
