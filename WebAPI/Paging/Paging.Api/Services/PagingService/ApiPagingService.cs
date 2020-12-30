using System;
using System.Linq;

namespace Paging.Api.Services.PagingService
{
    public class ApiPagingService : IPagingService
    {
        public IQueryable<T> GetPagedQuery<T>(IQueryable<T> query, PagingParameters parameters)
        {
            int totalRecord = query.Count();
            int totalPages = Convert.ToInt32(Math.Ceiling((double)totalRecord / (double)parameters.PageSize));
            int pageNumber = parameters.PageNumber > totalPages ? totalPages : parameters.PageNumber;

            return query.Skip((pageNumber - 1) * parameters.PageSize).Take(parameters.PageSize);
        }
    }
}