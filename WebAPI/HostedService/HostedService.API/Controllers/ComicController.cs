using System;
using System.Threading.Tasks;
using HostedService.API.Helpers;
using HostedService.API.Services.ComicService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace HostedService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicController : ControllerBase
    {
        private readonly ILogger<ComicController> _logger;
        private readonly IMemoryCache _cache;
        private readonly IComicService _comicService;

        public ComicController(ILogger<ComicController> logger, IMemoryCache cache, IComicService comicService)
        {
            _logger = logger;
            _cache = cache;
            _comicService = comicService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var comic = _cache.TryGetValue<Comic>(Constants.LatestComicCacheKey, out Comic res)
                    ? res
                    : await _comicService.RetrieveLastAsync();

                return Ok(comic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while retrieving comic");
                return BadRequest($"Exception occurred while retrieving comic");
            }
        }
    }
}
