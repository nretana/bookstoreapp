using AutoMapper;
using BookStore.API.Models.Books;
using BookStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/authors")]
    [Produces("application/json", "application/xml")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorService authorService, IMapper mapper) { 
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAuthors()
        {
            var authorList = await _authorService.GetAuthorsAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorList));
        }

        [HttpGet]
        [Route("{authorId}", Name = "GetAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthor(Guid authorId)
        {
            var authorFound = await _authorService.GetAuthorAsync(authorId);
            if(authorFound == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AuthorDto>(authorFound));
        }
    }
}
