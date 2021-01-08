using System.Threading.Tasks;

namespace HostedService.API.Services.HttpClientProxyService
{
    public interface IHttpClientProxyService
    {
        Task<T> GetAsync<T>(string uri) where T : class;
    }
}