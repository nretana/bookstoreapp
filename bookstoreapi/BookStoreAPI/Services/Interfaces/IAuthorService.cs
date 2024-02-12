using BookStore.API.Entities;

namespace BookStore.API.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();

        Task<Author> GetAuthorAsync(Guid authorId);
    }
}