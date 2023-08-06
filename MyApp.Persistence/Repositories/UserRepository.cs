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

        public UserRepository()
        {
            
        }

        public Task<List<User>> GetAllAsync()
        {
            var res = new List<User>();
            User user = new User() { Id = 1, Username = "Jack" };
            res.Add(user);
            return Task.FromResult(res);
            throw new NotImplementedException();
        }

    }
}
