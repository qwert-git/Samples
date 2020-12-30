using System.Linq;
using Paging.Api.Data;
using Paging.Api.Models;

namespace Paging.Api.Services.EntityReader
{
    public class EntityReader<T> : IEntityReader<T> where T : BaseEntity
    {
        private readonly ApiContext _context;

        public EntityReader(ApiContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query() => _context.Set<T>();
    }
}