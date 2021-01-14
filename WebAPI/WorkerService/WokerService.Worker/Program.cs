using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerService.Api.Configuration;
using WorkerService.Core.Services.FileStorageService;
using WorkerService.Core.Services.QueueMessageService;

namespace WokerService.Worker
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
                    services.AddTransient<IQueueMessageService>(ImplementationFactories.QueueMessageService);
                    services.AddTransient<IFileStorageService>(ImplementationFactories.FileStorageService);

                    services.AddHostedService<Worker>();
                });
    }
}
