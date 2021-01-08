using System;
using System.Threading;
using System.Threading.Tasks;
using HostedService.API.Helpers;
using HostedService.API.Services.ComicService;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedService.API.HostedServices
{
    public class ComicCacheBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ComicCacheBackgroundService> _logger;
        private readonly int PauseBetweenCallsMilliseconds;

        public ComicCacheBackgroundService(IMemoryCache cache, IServiceProvider services, IConfiguration config, ILogger<ComicCacheBackgroundService> logger)
        {
            _cache = cache;
            _services = services;
            _logger = logger;

            PauseBetweenCallsMilliseconds = config.GetValue<int>("AppSettings:DelayBetweenComicUpdateMin", defaultValue: 60) * 60 * 1000;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                LogInfo($"{typeof(ComicCacheBackgroundService)} task is executing.");

                using var scope = _services.CreateScope();
                var comicService = scope.ServiceProvider.GetRequiredService<IComicService>();

                var latestComic = await comicService.RetrieveLastAsync();
                _cache.Set<Comic>(Constants.LatestComicCacheKey, latestComic, TimeSpan.FromHours(4));

                LogInfo($"{typeof(ComicCacheBackgroundService)} task has been executed successfully.");

                await Task.Delay(PauseBetweenCallsMilliseconds);
            }
        }

        private void LogInfo(string message) => _logger.LogInformation(message);

        /* 
            [Use Cases for BackgroundService]
            -- Polling data from external service
            -- Responding external messages or events
            -- Performing data-intensive work
        */
    }
}