using Microsoft.Extensions.Configuration;
using Serilog;

namespace MyApp.Infrastructure.Logging
{
    public class SerilogConfigurator: ISerilogConfigurator
    {
        public void ConfigureSerilog(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateBootstrapLogger();
            }
    }
}
