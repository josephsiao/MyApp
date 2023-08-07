using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Mappings;
using MyApp.Application.Services.Implementations;
using MyApp.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            // 設定 AutoMapper
            services.AddAutoMapper(typeof(MappingProfile)); // 請確保指定了包含 AutoMapper 配置的類型
            return services;
        }
    }
}
