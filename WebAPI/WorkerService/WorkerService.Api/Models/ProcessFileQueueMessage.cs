namespace WorkerService.Api.Models
{
    public class ProcessFileQueueMessage : QueueMessageBase
    {
        public string FileName { get; set; }
    }
}