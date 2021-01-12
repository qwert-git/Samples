using System.Threading.Tasks;
using WorkerService.Api.Models;

namespace WorkerService.Api.Services.QueueMessageService
{
    public interface IQueueMessageService
    {
        Task EnqueueAsync<T>(T message) where T : QueueMessageBase;
    }
}