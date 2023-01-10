using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SQLIndexManager.Console;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        using var host =  CreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, builder) =>
            {
                builder
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true);
            })
            .ConfigureLogging((_, builder) =>
            {
                builder.AddSerilog();
            });
    }
}
