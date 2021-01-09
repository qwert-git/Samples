using System.Threading.Tasks;

namespace WorkerService.Api.Services.QueueMessageService
{
    public interface IQueueMessageService
    {
        Task EnqueueAsync<T>(T message) where T : class;
    }
}