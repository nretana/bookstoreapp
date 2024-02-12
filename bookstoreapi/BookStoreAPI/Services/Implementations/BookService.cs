using BookStore.API.DbContexts;
using BookStore.API.Entities;
using BookStore.API.Helpers;
using BookStore.API.Models.Books;
using BookStore.API.Services.Interfaces;
using LinqKit;
using LinqKit.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Xml;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.API.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly BookStoreContext _context;
        public BookService(BookStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PageList<Book>> GetBooksAsync(BookParamsRequestDto bookParamsRequestDto)
        {
            if (bookParamsRequestDto == null)
            {
                throw new ArgumentNullException(nameof(bookParamsRequestDto));
            }

            int pageSize = bookParamsRequestDto.PageSize;
            int pageNumber = bookParamsRequestDto.PageNumber;
            string searchQuery = bookParamsRequestDto.SearchQuery.ToLower();
            string orderBy = string.IsNullOrEmpty(bookParamsRequestDto.OrderBy.Trim()) ? 
                                                     "title asc" : bookParamsRequestDto.OrderBy.ToLower();

            var bookCollection = _context.Books.Include(a => a.Author)
                                               .Include(b => b.Genres)
                                               .Include(f => f.Format) as IQueryable<Book>;

            if (!string.IsNullOrEmpty(bookParamsRequestDto.Genres))
            {
                string genreFiltersQuery = bookParamsRequestDto.Genres.ToLower().Trim(',', ' ');
                List<string> genreFilters = genreFiltersQuery.Contains(',') ? genreFiltersQuery.Split(',').ToList<string>() :
                                                                        new List<string>() { genreFiltersQuery };

                var genreList = await _context.Genres.ToListAsync();
                var isValidGenres = genreFilters.TrueForAll(gf => genreList.Select(g => g.Name.ToLower()).Contains(gf));
                if (!isValidGenres)
                {
                    throw new Exception($"There are no genres that match your inputs {genreFiltersQuery}");
                }

                bookCollection = bookCollection.Where(MatchGenres(genreFilters));

                //bookCollection = bookCollection.Where(b => b.Genres.Any(g => IsGenreMatch(g, genreFilters)));
            }
            if (!string.IsNullOrEmpty(bookParamsRequestDto.Formats))
            {
                string formatFiltersQuery = bookParamsRequestDto.Formats.ToLower().Trim(',', ' ');
                List<string> formatFilters = formatFiltersQuery.Contains(',') ? formatFiltersQuery.Split(',').ToList<string>() :
                                                                        new List<string>() { formatFiltersQuery };

                var formatList = await _context.Formats.ToListAsync();
                var isValidFormats = formatFilters.TrueForAll(gf => formatList.Select(g => g.Name.ToLower()).Contains(gf));
                if(!isValidFormats)
                {
                    throw new Exception($"There are no formats that match your inputs {formatFiltersQuery}");
                }

                bookCollection = bookCollection.Where(b => formatFilters.Contains(b.Format.Name));
            }

            if (!string.IsNullOrEmpty(bookParamsRequestDto.SearchQuery.Trim()))
            {
                bookCollection = bookCollection.Where(MatchSearchQuery(searchQuery));
            }

            if (!string.IsNullOrEmpty(bookParamsRequestDto.OrderBy.Trim()))
            {
                bookCollection = bookCollection.OrderBy(orderBy);
            }

            return await PageList<Book>.CreateAsync(bookCollection, pageSize, pageNumber);
        }

        public async Task<Book> GetBookAsync(Guid bookId)
        {
            if (bookId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bookId));
            }

            var book = await _context.Books.Include(a => a.Author)
                                           .Include(g => g.Genres)
                                           .Include(f => f.Format)
                                           .SingleOrDefaultAsync(b => b.BookId == bookId);

            return book!;
        }



        /// <summary>
        /// Filter books by genres
        /// </summary>
        /// <param name="genre">current genre object from a query </param>
        /// <param name="genresFilter">genre list sent by the UI </param>
        /// <returns></returns>
        private static Func<Genre, List<string>, bool> IsGenreMatch = (Genre genre, List<string> genresFilter) =>
        {
            string name = genre.Name.ToLower();
            return genresFilter.Contains(name);
        };

        /// <summary>
        /// Expression for filtering books by genres
        /// </summary>
        /// <param name="genres">genre list sent by the UI </param>
        /// <returns></returns>
        private static Expression<Func<Book, bool>> MatchGenres(List<string> genres)
        {
            Expression<Func<Book, bool>> predicate = (book) => false;
            foreach (string genre in genres)
            {
                predicate = predicate.Or(b => (b.Genres.Any(g => g.Name.ToLower() == genre.ToLower())));
            }
            return predicate;
        }

        /// <summary>
        /// Expression for filtering books by text search
        /// </summary>
        /// <param name="searchQuery">text search sent by the UI </param>
        /// <returns></returns>
        private static Expression<Func<Book, bool>> MatchSearchQuery(string searchQuery)
        {
            Expression<Func<Book, bool>> predicate = (book) => false;

            predicate = predicate.Or(b => b.Title.ToLower().Contains(searchQuery) ||
                                          b.Description.ToLower().Contains(searchQuery) ||
                                          string.Concat(b.Author.FirstName.ToLower(), b.Author.LastName.ToLower()).Contains(searchQuery));
            
            return predicate;
        }
    }
}
