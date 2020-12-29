using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paging.Api.Models;
using Paging.Api.Services.Interfaces;

namespace Paging.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;

        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return Ok(books);
        }
    }
}