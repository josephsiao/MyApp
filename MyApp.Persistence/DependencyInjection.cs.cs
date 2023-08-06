using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.Repositories;
using MyApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // 註冊 IUserRepository 實現，使用 Dapper 或其他方式
            services.AddScoped<IUserRepository, UserRepository>();
            // 也可以註冊 IConfiguration，以便其他服務使用
            services.AddSingleton(configuration);

            return services;
        }
    }
}
