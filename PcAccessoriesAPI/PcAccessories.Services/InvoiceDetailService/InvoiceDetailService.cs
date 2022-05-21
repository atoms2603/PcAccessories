using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.InvoiceDetailService
{
    public class InvoiceDetailService : BaseService<InvoiceDetail>, IInvoiceDetailService
    {
        public InvoiceDetailService(PcAccessoriesDbContext context) : base(context)
        {
        }
    }
}
