namespace BookStore.API.Models.Books
{
    public class FormatDto
    {
        public Guid FormatId { get; set; }
        
        public string Name { get; set; } = string.Empty;
    }
}
