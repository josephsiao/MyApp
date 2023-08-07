using Microsoft.Extensions.Configuration;
using MyApp.Application;
using MyApp.Infrastructure;
using MyApp.Infrastructure.Logging;
using MyApp.Persistence;
using MyApp.Shared;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    // �]�m IConfiguration�AŪ�� appsettings.json ���
    ConfigurationManager configuration = builder.Configuration;
    // Add services to the container.
    var configRoot = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName ?? "Production"}.json", true)
        .Build();
    ;
    configuration.AddConfiguration(configRoot);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
    );
    //builder.Host.UseSerilog();
    builder.Services.AddControllers();

    // ���U MyApp.Application �M�פ����A��
    builder.Services.AddApplication();
    builder.Services.AddPersistence(configuration);
    builder.Services.AddInfrastructure();
    builder.Services.AddShared();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    // �q DI �e����� ISerilogConfigurator �A�Ȩðt�m Serilog
    var serilogConfigurator = app.Services.GetRequiredService<ISerilogConfigurator>();
    serilogConfigurator.ConfigureSerilog(configuration);
    Log.Information("Starting");
    app.UseSerilogRequestLogging(options =>
    {
        options.MessageTemplate =
            "Handled - Requester [{RequestUser}] Action [{RequestMethod}] {RequestPath} responded [{StatusCode}] Elapsed [{Elapsed:0.00000.0000}ms]";
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("RequestUser", httpContext.Request.Headers["UserName"]);
        };
    });
    //var serilogConfigurator = app.Services.GetRequiredService<ISerilogConfigurator>();
    //serilogConfigurator.ConfigureSerilog(app.Configuration);
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    Log.Information("Application started");
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}