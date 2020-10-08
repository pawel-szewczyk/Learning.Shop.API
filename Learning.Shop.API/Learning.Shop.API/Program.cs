using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Learning.Shop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var environment = context.HostingEnvironment;
                    config.SetBasePath(environment.ContentRootPath)
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();
                })
                .UseSerilog((hostingContext, services, loggerConfiguration) =>
                    loggerConfiguration
                        .ReadFrom.Configuration(hostingContext.Configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
