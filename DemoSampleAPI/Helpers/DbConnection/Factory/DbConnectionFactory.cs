using System;
using System.Data;
using MySqlConnector;

namespace DemoSampleAPI.Helpers.DbConnection.Services;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("DefaultConnection")!;
    }
}
