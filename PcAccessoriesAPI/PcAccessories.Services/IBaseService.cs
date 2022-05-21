using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Services
{
    public interface IBaseService<T> where T : class
    {
        Task InsertAsync(T entity);
        Task BulkInsertAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task BulkUpdateAsync(List<T> entities);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAllQuery();
    }
}
