using System.Collections.Generic;
using System.Threading.Tasks;
using Paging.Api.Models;

namespace Paging.Api.Services.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
    }
}