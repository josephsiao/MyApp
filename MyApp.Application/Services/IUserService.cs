using MyApp.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
