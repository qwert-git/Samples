using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using WorkerService.Core.Models;
using Microsoft.Extensions.Logging;

namespace WorkerService.Core.Services.QueueMessageService
{
    public class AzureServiceBusQueueMessageService : IQueueMessageService
    {
        private readonly QueueClient _queueClient;
        private readonly ILogger<AzureServiceBusQueueMessageService> _logger;

        public AzureServiceBusQueueMessageService(QueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public Task EnqueueAsync<T>(T message) where T : QueueMessageBase
        {
            string data = JsonConvert.SerializeObject(message);

            var queueMessage = new Message(Encoding.UTF8.GetBytes(data));

            return _queueClient.SendAsync(queueMessage);
        }

        public void RegisterHandler<T>(Func<T, CancellationToken, Task> handler) where T : QueueMessageBase
        {
            _queueClient.RegisterMessageHandler(async (message, token) =>
            {
                var queueMessage = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(message.Body));
                await handler(queueMessage, token);
            },
            (args) =>
            {
                _logger.LogError(args.Exception, "An error occured while queue message processing.");
                return Task.CompletedTask;
            });
        }
    }
}