using System;
using System.Collections.Generic;
using Paging.Api.Data.Models;

namespace Paging.Api.Data
{
    public static class Seed
    {
        public static void PopulateBooks(ApiContext context)
        {
            var books = new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Name = "In Search of Lost Time", Author = "Marcel Proust", Capacity = 134, Publisher = "Book Publisher in UA" },
                new Book { Id = Guid.NewGuid(), Name = "One Hundred Years of Solitude", Author = "Gabriel Garcia Marquez", Capacity = 221, Publisher = "Book Publisher in UA" },
                new Book { Id = Guid.NewGuid(), Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", Capacity = 174, Publisher = "Book Publisher in UA" },
                new Book { Id = Guid.NewGuid(), Name = "Moby Dick", Author = "Herman Melville", Capacity = 244, Publisher = "Book Publisher in UA" }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}