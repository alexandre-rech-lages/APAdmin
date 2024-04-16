using Serilog;

namespace APAdmin.WebApi.Config;

public static class SerilogConfigExtension
{
    public static void ConfigureSerilog(this ILoggingBuilder loggingBuilder)
    {
        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(logger, dispose: true);
    }
}