using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService.Core.Services.FileStorageService
{
    public interface IFileStorageService
    {
        Task<bool> UploadFileAsync(Stream stream, string fileName, CancellationToken ct = default(CancellationToken));
        Task<string> ReadFileAsync(string fileName, CancellationToken ct = default(CancellationToken));
    }
}