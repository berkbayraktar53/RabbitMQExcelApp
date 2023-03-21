using System;
using RabbitMQ.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FileCreateWorkerService.Models;
using FileCreateWorkerService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileCreateWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration Configuration = hostContext.Configuration;
                services.AddDbContext<AdventureWorks2017Context>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
                });
                services.AddSingleton<RabbitMQClientService>();
                services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(Configuration.GetConnectionString("RabbitMQ")), DispatchConsumersAsync = true });
                services.AddHostedService<Worker>();
            });
    }
}