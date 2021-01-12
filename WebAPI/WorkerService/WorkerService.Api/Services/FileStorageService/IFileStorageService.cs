using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService.Api.Services.FileStorageService
{
    public interface IFileStorageService
    {
        Task<bool> UploadFileAsync(Stream stream, string fileName, CancellationToken ct = default(CancellationToken));
    }
}