namespace BookStore.API.Entities
{
    public class Format
    {
        public Guid FormatId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set;} = new HashSet<Book>();
    }
}
