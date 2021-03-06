using System.Linq;

namespace Paging.Api.Services.PagingService
{
    public interface IPagingService
    {
        IQueryable<T> GetPagedQuery<T>(IQueryable<T> query, PagingParameters parameters);
    }
}