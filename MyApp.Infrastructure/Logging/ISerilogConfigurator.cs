using Microsoft.Extensions.Configuration;

namespace MyApp.Infrastructure.Logging
{
    public interface ISerilogConfigurator
    {
        void ConfigureSerilog(IConfiguration configuration);
    }
}
