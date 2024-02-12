using BookStore.API.Entities;
using BookStore.API.Helpers;
using BookStore.API.Models.Books;

namespace BookStore.API.Services.Interfaces
{
    public interface IBookService
    {
        Task<PageList<Book>> GetBooksAsync(BookParamsRequestDto bookParamsRequestDto);

        Task<Book> GetBookAsync(Guid bookId);
    }
}
