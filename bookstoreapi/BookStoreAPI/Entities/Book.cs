using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Entities
{

    public class Book
    {

        public Guid BookId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Isbn { get; set; } = null!;

        public DateTime PublishedDate { get; set; }

        public int Pages { get; set; }

        public string ImageUrl { get; set; } = null!;



        //RELATIONSHIPS
        public Guid FormatId { get; set; }

        public Format Format { get; set; } = null!;

        public Guid AuthorId { get; set; }
        
        public Author Author { get; set; } = null!;

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
        
    }
}
