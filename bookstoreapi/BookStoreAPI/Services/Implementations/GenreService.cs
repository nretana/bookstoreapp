using BookStore.API.DbContexts;
using BookStore.API.Entities;
using BookStore.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly BookStoreContext _context;
        public GenreService(BookStoreContext context) { 

            _context= context ?? throw new ArgumentNullException(nameof(context));  
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genres.OrderBy(g => g.Name).ToListAsync();
        }
    }
}
