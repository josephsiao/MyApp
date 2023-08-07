using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        // 其他方法...
    }
}
