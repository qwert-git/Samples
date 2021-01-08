using System.Threading.Tasks;

namespace HostedService.API.Services.ComicService
{
    public interface IComicService
    {
        Task<Comic> RetrieveLastAsync();
    }
}