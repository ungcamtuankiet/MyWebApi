using System;
using System.Collections.Generic;

namespace MyWebAppApi.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize) 
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
    }
}
