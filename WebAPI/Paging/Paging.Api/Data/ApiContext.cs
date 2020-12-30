using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Paging.Api.Data.Models;

namespace Paging.Api.Data
{
    public class ApiContext : DbContext
    {
        private readonly IConfiguration _config;

        public ApiContext(DbContextOptions<ApiContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_config.GetValue<bool>("AppSettings:EnableDBTrace", false))
                optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}