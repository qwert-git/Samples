using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using WorkerService.Core.Models;

namespace WorkerService.Core.Services.QueueMessageService
{
    public class AzureServiceBusQueueMessageService : IQueueMessageService
    {
        private readonly QueueClient _queueClient;

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
    }
}