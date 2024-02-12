using BookStore.API.Entities;

namespace BookStore.API.Services.Interfaces
{
    public interface IFormatService
    {
        Task<IEnumerable<Format>> GetFormatsAsync();

    }
}
