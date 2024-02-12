
namespace BookStore.API.Models.Books
{
    public class BookDto
    {
        public Guid BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public AuthorDto Author { get; set; } = null!;

        public string Isbn { get; set; } = string.Empty;

        public FormatDto Format { get; set; } = null!;

        public DateTime PublishedDate { get; set; }

        public int Pages { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<GenreDto> Genres { get; set; } = new HashSet<GenreDto>();

    }
}
