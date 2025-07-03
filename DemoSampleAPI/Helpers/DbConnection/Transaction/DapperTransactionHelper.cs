using System.Data;
using MySqlConnector;

namespace DemoSampleAPI.Helpers.DbConnection.Transaction;

public static class DapperTransactionHelper
{
    public static async Task<T> ExecuteAsync<T>(string connectionString, Func<IDbConnection, IDbTransaction, Task<T>> operation)
    {
        await using var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync();
        using var transaction = await connection.BeginTransactionAsync();
        try
        {
            var result = await operation(connection, transaction);
            await transaction.CommitAsync();
            return result;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public static async Task ExecuteAsync(string connectionString, Func<IDbConnection, IDbTransaction, Task> operation)
    {
        await using var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync();
        using var transaction = await connection.BeginTransactionAsync();
        try
        {
            await operation(connection, transaction);
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
