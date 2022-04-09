using PcAccessories.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PcAccessories.Services.CMS.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetALL();
    }
}
