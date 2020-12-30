using System.Linq;
using Paging.Api.Data.Models;

namespace Paging.Api.Services.EntityReader
{
    public interface IEntityReader<out T> where T : BaseEntity
    {
        IQueryable<T> Query();
    }
}