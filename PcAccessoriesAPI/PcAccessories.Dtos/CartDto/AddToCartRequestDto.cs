using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.CartDto
{
    public class AddToCartRequestDto
    {
        [Required] 
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
