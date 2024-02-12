using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BookStore.API.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages { get; private set; }

        public int TotalCount { get; private set; }

        public bool HasPrevious => (CurrentPage > 1);

        public bool HasNext => (CurrentPage < TotalPages);

        public PageList(List<T> items, int totalCount, int pageSize, int pageNumber) {
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
            CurrentPage = pageNumber;
            AddRange(items);
        }

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageSize, int pageNumber)
        {
            int numOfItems = source.Count();
            int newPageNumber = numOfItems <= pageSize ? 1 : pageNumber;
            int skipNumOfPages = numOfItems <= pageSize ? 0 : pageSize * (pageNumber - 1);

            var itemList = await source.Skip(skipNumOfPages).Take(pageSize).ToListAsync();
            return new PageList<T>(itemList, numOfItems, pageSize, newPageNumber);
        }
    }
}
