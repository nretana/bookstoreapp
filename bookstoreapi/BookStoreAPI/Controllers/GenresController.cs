using AutoMapper;
using BookStore.API.Models.Books;
using BookStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/genres")]
    [Produces("application/json", "application/xml")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper) { 
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGenres()
        {
            var genreList = await _genreService.GetGenresAsync();
            return Ok(_mapper.Map<IEnumerable<GenreDto>>(genreList));
        }
    }
}
