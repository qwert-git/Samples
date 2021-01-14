using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkerService.Core.Models;
using WorkerService.Core.Services.FileStorageService;
using WorkerService.Core.Services.QueueMessageService;

namespace WokerService.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var queueService = _serviceProvider.GetRequiredService<IQueueMessageService>();
            var fileStorageService = _serviceProvider.GetRequiredService<IFileStorageService>();

            queueService.RegisterHandler<ProcessFileQueueMessage>(async (message, token) =>
            {
                var data = await fileStorageService.ReadFileAsync(message.FileName, token);

                Console.WriteLine("Processing File..");
                Console.WriteLine($"FileName: {message.FileName}");
                Console.WriteLine($"Notification time: {message.Time}");

                Console.WriteLine($"Content: {data.Substring(0, 20)}");
            });

            return Task.CompletedTask;
        }
    }
}
