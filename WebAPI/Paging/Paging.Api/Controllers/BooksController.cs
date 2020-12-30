using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paging.Api.Services.PagingService;
using Microsoft.EntityFrameworkCore;
using Paging.Api.Services.EntityReader;
using Paging.Api.Data.Models;
using Paging.Api.ApiModels;

namespace Paging.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IEntityReader<Book> _booksReader;
        private readonly IPagingService _pagingService;

        public BooksController(IEntityReader<Book> booksReader, IPagingService pagingService)
        {
            _booksReader = booksReader;
            _pagingService = pagingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetBooksParameters parameters)
        {
            var booksQuery = _booksReader.Query();

            var result = await _pagingService.GetPagedQuery(booksQuery, new PagingParameters(parameters.PageNumber, parameters.PageSize)).ToListAsync();

            return Ok(result);
        }
    }
}