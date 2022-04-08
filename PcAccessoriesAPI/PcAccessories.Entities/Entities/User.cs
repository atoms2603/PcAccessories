﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public List<ProductLove> ProductLoves { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}