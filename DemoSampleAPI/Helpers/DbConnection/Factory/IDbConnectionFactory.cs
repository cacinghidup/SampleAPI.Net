using System;
using System.Data;

namespace DemoSampleAPI.Helpers.DbConnection.Services;

public interface IDbConnectionFactory
{
     IDbConnection CreateConnection();
     string GetConnectionString();
}
