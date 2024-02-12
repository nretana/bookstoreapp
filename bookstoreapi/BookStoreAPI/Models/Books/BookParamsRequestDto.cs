using MailKit.Search;
using Microsoft.AspNetCore.Http.Features;

namespace BookStore.API.Models.Books
{
    public class BookParamsRequestDto
    {
        const int maxPageSize = 20;
        private int _pageSize = 1;
        private int _pageNumber = 1;


        public string Genres { get; set; } = string.Empty;

        public string Formats { get; set; } = string.Empty;

        public string SearchQuery { get; set; } = string.Empty;

        public string OrderBy { get; set; } = string.Empty;

        public int PageSize { get => _pageSize; 
                              set => _pageSize = (value > maxPageSize) ? maxPageSize : value; 
                            }
 
        public int PageNumber { get => _pageNumber; 
                                set => _pageNumber = (value <= 0) ? _pageNumber : value ; }


    }
}
