namespace BookStore.API.Models.Books
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;

        public DateTimeOffset DateOfBirth { get; set; }

        public string CountryOfBirth { get; set; } = string.Empty;

        public string PlaceOfBirth { get; set; } = string.Empty;

        public DateTimeOffset DateCreated { get; set; }
    }
}
