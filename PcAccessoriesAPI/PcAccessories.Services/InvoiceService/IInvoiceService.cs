using PcAccessories.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PcAccessories.Services.InvoiceService
{
    public interface IInvoiceService : IBaseService<Invoice>
    {
        Task<List<Invoice>> GetInvoiceByUserIdAsync(Guid userId);
        Task<Invoice> GetInvoiceByIdAsync(Guid invoiceId);
    }
}
