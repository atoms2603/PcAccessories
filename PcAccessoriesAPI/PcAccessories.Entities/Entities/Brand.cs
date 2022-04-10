﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Entities.Entities
{
    public class Brand : BaseEntity
    {
        public Guid BrandId { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }
    }
}
