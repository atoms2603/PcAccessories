using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.Pagination.Request
{
    public class PagingRequestDto
    {
        [Range(1, 2147483647)]
        public int PageSize { get; set; } = 10;

        [Range(1, 2147483647)]
        public int PageIndex { get; set; } = 1;

        public int Offset // 1 - 0
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }
    }
}
