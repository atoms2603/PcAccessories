using Microsoft.EntityFrameworkCore;
using PcAccessories.EFCore.Data;
using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services.InvoiceService
{
    public class InvoiceService : BaseService<Invoice>, IInvoiceService
    {
        public InvoiceService(PcAccessoriesDbContext context) : base(context)
        {
        }
        
        public async Task<List<Invoice>> GetInvoiceByUserIdAsync(Guid userId)
        {
            return await _context.Invoices.Where(x=> x.UserId == userId).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(Guid invoiceId)
        {
            return await _context.Invoices.Where(x => x.InvoiceId == invoiceId).FirstOrDefaultAsync();
        }
    }
}
