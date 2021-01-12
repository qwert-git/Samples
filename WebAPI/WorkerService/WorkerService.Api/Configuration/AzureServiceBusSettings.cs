using Microsoft.Azure.ServiceBus;

namespace WorkerService.Api.Configuration
{
    public class AzureServiceBusSettings
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}