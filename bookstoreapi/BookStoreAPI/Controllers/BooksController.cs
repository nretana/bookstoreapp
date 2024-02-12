using AutoMapper;
using BookStore.API.Models.Books;
using BookStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper) { 
        
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBooks([FromQuery]BookParamsRequestDto bookParamsRequestDto)
        {
            var bookResult = await _bookService.GetBooksAsync(bookParamsRequestDto);

            var paginationMetadata = new
            {
                totalCount = bookResult.TotalCount,
                totalPages = bookResult.TotalPages,
                pageSize = bookResult.PageSize,
                currentPage = bookResult.CurrentPage,
                hasPrevious = bookResult.HasPrevious,
                hasNext = bookResult.HasNext
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<BookDto>>(bookResult));
        }

        [HttpGet("{bookId}", Name = "GetBook")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookB(Guid bookId)
        {
            var bookFound = await _bookService.GetBookAsync(bookId);
            if(bookFound == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(bookFound));
        }

        [HttpOptions]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS");
            return Ok();
        }
    }
}
