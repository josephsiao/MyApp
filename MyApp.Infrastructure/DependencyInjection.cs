using Microsoft.Extensions.DependencyInjection;
using MyApp.Infrastructure.Logging;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ISerilogConfigurator, SerilogConfigurator>();
            //services.AddSingleton<ISerilogConfigurator, SerilogConfigurator>();

            // 其他註冊...

            return services;
        }
    }
}
