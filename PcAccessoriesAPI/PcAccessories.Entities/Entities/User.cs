using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class User : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<ProductLove> ProductLoves { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
