using System.ComponentModel;

namespace BookStore.API.DataTransfers.Responses
{
    public class Response<T> where T : class
    {
        public T Data { get; set; } = default!;

        public bool IsSucceeded { get; set; }

        public IEnumerable<Error> Errors { get; set; } = null!;
    }
}
