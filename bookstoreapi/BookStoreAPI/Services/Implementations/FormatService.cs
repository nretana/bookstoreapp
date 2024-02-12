using BookStore.API.DbContexts;
using BookStore.API.Entities;
using BookStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services.Implementations
{
    public class FormatService : IFormatService
    {
        private readonly BookStoreContext _context;
        public FormatService(BookStoreContext context) {

            _context= context ?? throw new ArgumentNullException(nameof(context));
        
        }

        public async Task<IEnumerable<Format>> GetFormatsAsync()
        {
            return await _context.Formats.OrderBy(f => f.Name).ToListAsync();
        }
    }
}
