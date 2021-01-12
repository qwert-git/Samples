using System;

namespace WorkerService.Core.Models
{
    public abstract class QueueMessageBase
    {
        public DateTime Time { get; set; }
    }
}