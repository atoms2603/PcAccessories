using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.Pagination
{
    public class PagingResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long TotalPages { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public PagingResult(List<T> data, int totalCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            Data = data;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}
