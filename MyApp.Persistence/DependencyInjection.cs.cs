using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.Repositories;
using MyApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MyApp.Domain.Models;
using MyApp.Shared.Common;

namespace MyApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // 註冊 IUserRepository 實現，使用 Dapper 或其他方式
            services.AddScoped<IUserRepository, UserRepository>();

            // 註冊 IDbConnectionFactory，根據需求選擇工廠類型
            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();
            // services.AddScoped<IDbConnectionFactory, MySqlConnectionFactory>();
            // 設定類型映射
            ConfigureTypeMappings();
            // 也可以註冊 IConfiguration，以便其他服務使用
            services.AddSingleton(configuration);

            return services;
        }

        private static void ConfigureTypeMappings()
        {
            // 這裡可以放置多個類型映射的設置
            SqlMapper.SetTypeMap(typeof(User), new ColumnAttributeTypeMapper<User>());
            // 如果有其他模型，也可以在這裡設定類型映射
        }
    }
}
