using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.Cms.InvoiceAPI
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class InvoiceController : APIControllerBase
    {
    }
}
