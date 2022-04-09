using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers
{
    public class APIControllerBase : ControllerBase
    {
        private string _userName = null;
        private string _email = null;
        private Guid? _userId = null;

        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public string UserName
        {
            get
            {
                if (_userName == null)
                {
                    _userName = GetClaimValue("Labbit:UserName");
                }
                return _userName;
            }
        }
        public string Email
        {
            get
            {
                if (_email == null)
                {
                    _email = GetClaimValue("Labbit:Email");
                }
                return _email;
            }
        }
        public Guid? UserId
        {
            get
            {
                if (_userId == null
                    && Guid.TryParse(GetClaimValue("Labbit:UserId"), out Guid userId))
                {
                    _userId = userId;
                }
                return _userId;
            }
        }

        private string GetClaimValue(string type)
        {
            return HttpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == type)?.Value;
        }
    }
}
