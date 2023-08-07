using Dapper;
using MyApp.Domain.Models;
using MyApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private readonly IDbConnection _dbConnection;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<User>> GetAllAsync()
        {
            //Dapper.SqlMapper.SetTypeMap(
            //    typeof(User),
            //    new ColumnAttributeTypeMapper<User>());
            using var connection = _dbConnectionFactory.CreateConnection("SqlServerConnection");
            // 使用連接執行操作，例如使用 Dapper 執行查詢
            var users = await connection.QueryAsync<User>("SELECT user_id, user_name FROM MyAppUser");
            return users.AsList();
            //var res = new List<User>();
            //User user = new User() { Id = 1, Username = "Jack" };
            //res.Add(user);
            //return Task.FromResult(res);
            throw new NotImplementedException();
        }

    }
}
