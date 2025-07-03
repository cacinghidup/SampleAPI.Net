using System;
using Dapper;
using DemoSampleAPI.Helpers.DbConnection.Services;
using DemoSampleAPI.Helpers.DbConnection.Transaction;
using DemoSampleAPI.User.Models;

namespace DemoSampleAPI.User.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UserRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public bool CheckUsername(string username)
    {
        using var conn = _dbConnectionFactory.CreateConnection();
        var sql = @"SELECT COUNT(*) FROM Users u WHERE u.Username = @Username;";
        var result = conn.QuerySingleAsync<int>(sql, username);
        return result.Result == 0;
    }

    public async Task<int> CreateAsync(UserModel user)
    {
        return await DapperTransactionHelper.ExecuteAsync(_dbConnectionFactory.GetConnectionString(), async (conn, transaction) =>
        {
            var sql = @"INSERT INTO Users(Username, PasswordHash, Email, TelCode, Telephone) VALUES (@Username, @PasswordHash, @Email, @TelCode, @Telephone); 
                        SELECT LAST_INSERT_ID()";
            return await conn.ExecuteScalarAsync<int>(sql, user, transaction);
        });
    }

    public Task<IEnumerable<UserModel>> SearchByUsername(string username)
    {
        using var conn = _dbConnectionFactory.CreateConnection();
        var sql = @"SELECT * FROM Users u WHERE u.Username LIKE @Username;";
        var result = conn.QueryAsync<UserModel>(sql, username);
        return result;
    }
}
