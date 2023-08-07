using Microsoft.Extensions.Configuration;
using MyApp.Persistence.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.DataAccess.Implementations
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection(string connectionStringName)
        {
            string connectionString = _configuration.GetConnectionString(connectionStringName);
            return new SqlConnection(connectionString);
        }
    }
}
