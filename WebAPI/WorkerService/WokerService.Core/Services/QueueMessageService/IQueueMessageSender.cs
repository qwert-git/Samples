using System;
using System.Threading;
using System.Threading.Tasks;
using WorkerService.Core.Models;

namespace WorkerService.Core.Services.QueueMessageService
{
    public interface IQueueMessageService
    {
        Task EnqueueAsync<T>(T message) where T : QueueMessageBase;
        void RegisterHandler<T>(Func<T, CancellationToken, Task> handler) where T : QueueMessageBase;
    }
}