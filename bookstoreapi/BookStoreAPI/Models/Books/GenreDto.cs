namespace BookStore.API.Models.Books
{
    public class GenreDto
    {
        public Guid GenreId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
