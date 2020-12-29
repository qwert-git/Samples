using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paging.Api.Models;
using Paging.Api.Services.Interfaces;

namespace Paging.Api.Services.BooksRepository
{
    public class BooksRepository : IRepository<Book>
    {
        private static IList<Book> _context = new List<Book>
        {
            new Book { Id = Guid.NewGuid(), Name = "In Search of Lost Time", Author = "Marcel Proust", Capacity = 134, Publisher = "Book Publisher in UA" },
            new Book { Id = Guid.NewGuid(), Name = "One Hundred Years of Solitude", Author = "Gabriel Garcia Marquez", Capacity = 221, Publisher = "Book Publisher in UA" },
            new Book { Id = Guid.NewGuid(), Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", Capacity = 174, Publisher = "Book Publisher in UA" },
            new Book { Id = Guid.NewGuid(), Name = "Moby Dick", Author = "Herman Melville", Capacity = 244, Publisher = "Book Publisher in UA" }
        };

        public void Add(Book entity)
        {
            _context.Add(entity);
        }

        public void Delete(Book entity)
        {
            _context.Remove(entity);
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            return Task.FromResult(_context.AsEnumerable());
        }

        public Task<Book> GetAsync(string id)
        {
            return Task.FromResult(_context.FirstOrDefault(b => b.Id == Guid.Parse(id)));
        }

        public Task<bool> SaveChangesAsync()
        {
            return Task.FromResult(true);
        }
    }
}