using System.Threading.Tasks;
using HostedService.API.Services.HttpClientProxyService;

namespace HostedService.API.Services.ComicService
{
    public class WebComicService : IComicService
    {
        private readonly IHttpClientProxyService _httpProxy;

        public WebComicService(IHttpClientProxyService httpProxy)
        {
            _httpProxy = httpProxy;
        }

        public Task<Comic> RetrieveLastAsync() => _httpProxy.GetAsync<Comic>("info.0.json");
    }
}