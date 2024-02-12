using AutoMapper;
using BookStore.API.Models.Books;
using BookStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/formats")]
    public class FormatsController : ControllerBase
    {
        private readonly IFormatService _formatService;
        private readonly IMapper _mapper;

        public FormatsController(IFormatService formatService, IMapper mapper) { 
            _formatService = formatService ?? throw new ArgumentNullException(nameof(formatService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFormats() {
            var formatList = await _formatService.GetFormatsAsync();
            return Ok(_mapper.Map<IEnumerable<FormatDto>>(formatList));
        }
    }
}
