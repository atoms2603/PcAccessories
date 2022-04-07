﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
    }
}
