using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.Dtos.UsersDto.Response
{
    public class GetListUserResponseDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public DateTime LastLogInTime { get; set; }
        public string RoleName { get; set; }
    }
}
