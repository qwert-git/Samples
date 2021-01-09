namespace WorkerService.Api.Configuration
{
    public class AzureServiceBusSettings
    {
        public string AccessKey { get; set; }
        public string AccessKeyName { get; set; }
        public string Namespace { get; set; }
        public string Scheme { get; set; }
        public string QueueName { get; set; }
    }
}