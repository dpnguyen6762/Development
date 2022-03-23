using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

// DI, Serilog, Settings

namespace DeanConsoleUI
{
    class program
    {
        static void Main(string[] Args)
        {
            // See https://aka.ms/new-console-template for more information
            //Console.WriteLine("Hello, World!");

            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("ApplicationException Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IGreetingService, GreetingService>();
                }
                )
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
            svc.Run();


        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            // talk to the configuration source
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
                
        }
    }
}

namespace DeanConsoleUI
{
}