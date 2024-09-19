using System;
using System.Collections.Generic;

namespace ProductData.Models
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; }
        public int TotalCount { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PaginatedList(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount; // Assign the correct value to TotalCount
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
