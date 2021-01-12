using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace WorkerService.Api.Services.FileStorageService
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
    }
}