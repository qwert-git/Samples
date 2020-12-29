using System.Linq;

namespace Paging.Api.Services.PagingService
{
    public class ApiPagingService : IPagingService
    {
        public IQueryable<T> GetPagedQuery<T>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}