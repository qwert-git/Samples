namespace WorkerService.Core.Models
{
    public class ProcessFileQueueMessage : QueueMessageBase
    {
        public string FileName { get; set; }
    }
}