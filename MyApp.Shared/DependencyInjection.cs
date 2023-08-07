using MyApp.Shared.Common;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddSingleton<ISerilogConfigurator, SerilogConfigurator>();
            //var serilogConfigurator = new SerilogConfigurator(); // 實例化 SerilogConfigurator
            //services.AddSingleton<ISerilogConfigurator>(serilogConfigurator);
            // 可以在這裡註冊其他通用的服務...

            return services;
        }
    }
}
