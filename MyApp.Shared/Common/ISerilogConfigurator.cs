using Microsoft.Extensions.Configuration;

namespace MyApp.Shared.Common
{
    public interface ISerilogConfigurator
    {
        void ConfigureSerilog(IConfiguration configuration);
    }
}
