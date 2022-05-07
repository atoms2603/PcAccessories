using PcAccessories.Dtos.Pagination.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.CategoryDto.Request
{
    public class GetListCategoryRequestDto : PagingRequestDto
    {
        public string SortBy { get; set; }

        public string SortOrder { get; set; }

        public string Keyword { get; set; }
    }
}
