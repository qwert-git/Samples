using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkerService.Core.Models;
using WorkerService.Core.Services.FileStorageService;
using WorkerService.Core.Services.QueueMessageService;

namespace WorkerService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbContentController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IQueueMessageService _queueMessageService;
        private readonly ILogger<DbContentController> _logger;

        public DbContentController(IFileStorageService fileStorageService, IQueueMessageService queueMessageService, ILogger<DbContentController> logger)
        {
            _fileStorageService = fileStorageService;
            _queueMessageService = queueMessageService;
            _logger = logger;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadDbContentFile([FromForm] IFormFile file)
        {
            try
            {
                if (file is null)
                    return BadRequest("File has not been uploaded!");

                using var fstream = file.OpenReadStream();
                if (await _fileStorageService.UploadFileAsync(fstream, file.FileName))
                {
                    var message = new ProcessFileQueueMessage { FileName = file.FileName, Time = DateTime.UtcNow };
                    await _queueMessageService.EnqueueAsync<ProcessFileQueueMessage>(message);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unandled exception occured while uploading db content file.");
                return BadRequest("Uploading Db Content file failed.");
            }
        }
    }
}