using System;

namespace WorkerService.Api.Models
{
    public abstract class QueueMessageBase
    {
        public DateTime Time { get; set; }
    }
}