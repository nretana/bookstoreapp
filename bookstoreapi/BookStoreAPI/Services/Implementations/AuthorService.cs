using BookStore.API.DbContexts;
using BookStore.API.Entities;
using BookStore.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreContext _context;
        public AuthorService(BookStoreContext context) { 
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetAuthorAsync(Guid authorId)
        {
            if(authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            var author = await _context.Authors.SingleOrDefaultAsync(a => a.AuthorId == authorId);
            return author!;
        }
    }
}
