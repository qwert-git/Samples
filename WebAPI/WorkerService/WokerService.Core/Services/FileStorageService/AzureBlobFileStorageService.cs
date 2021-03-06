using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace WorkerService.Core.Services.FileStorageService
{
    public class AzureBlobFileStorageService : IFileStorageService
    {
        private readonly BlobContainerClient _blobContainer;

        public AzureBlobFileStorageService(BlobContainerClient blobClient)
        {
            _blobContainer = blobClient;
        }

        public async Task<bool> UploadFileAsync(Stream stream, string fileName, CancellationToken ct = default(CancellationToken))
        {
            var res = await _blobContainer.UploadBlobAsync(fileName, stream, ct);

            var response = res.GetRawResponse();

            return response.Status >= 200 && response.Status < 300;
        }

        public async Task<string> ReadFileAsync(string fileName, CancellationToken ct = default(CancellationToken))
        {
            var blobClient = _blobContainer.GetBlobClient(fileName);
            var blobDownloadInfo = await blobClient.DownloadAsync();

            using (var sr = new StreamReader(blobDownloadInfo.Value.Content))
            {
                return await sr.ReadToEndAsync();
            }
        }
    }
}