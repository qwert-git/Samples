using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HostedService.API.Services.HttpClientProxyService
{
    public class HttpClientProxyService : IHttpClientProxyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientProxyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync<T>(string uri) where T : class
        {
            using var httpClient = _httpClientFactory.CreateClient("comicServer");

            string data = await httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}