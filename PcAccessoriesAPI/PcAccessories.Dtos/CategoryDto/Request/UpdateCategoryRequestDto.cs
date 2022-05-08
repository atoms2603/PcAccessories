using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.CategoryDto.Request
{
    public class UpdateCategoryRequestDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
