using BookStore.API.Entities;

namespace BookStore.API.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
    }
}