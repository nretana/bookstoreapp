namespace BookStore.API.Entities
{
    public class Genre
    {

        public Guid GenreId { get; set; }

        public string Name { get; set; } = null!;

        
        public ICollection<Book>? Books { get; set; } = new HashSet<Book>();

    }
}
