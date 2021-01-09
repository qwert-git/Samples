using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace WorkerService.Api.Services.QueueMessageService
{
    public class AzureServiceBusQueueMessageService : IQueueMessageService
    {
        private readonly QueueClient _queueClient;

        public AzureServiceBusQueueMessageService(NamespaceManager namespaceManager, string queueName)
        {
            var messagingFactory = MessagingFactory.Create(namespaceManager.Address, namespaceManager.Settings.TokenProvider);
            _queueClient = messagingFactory.CreateQueueClient(queueName);
        }

        public Task EnqueueAsync<T>(T message) where T : class
        {
            return _queueClient.SendAsync(new BrokeredMessage(message));
        }
    }
}