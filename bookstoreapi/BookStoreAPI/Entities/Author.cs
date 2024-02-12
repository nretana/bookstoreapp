using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Entities
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Biography { get; set; } = string.Empty;

        public DateTimeOffset? DateOfBirth { get; set; } = null!;

        public string? CountryOfBirth { get; set; } = string.Empty;

        public string? PlaceOfBirth { get; set; } = string.Empty;

        public DateTimeOffset DateCreated { get; set; }



        public ICollection<Book> Books { get; set; } = new HashSet<Book>();

    }
}
