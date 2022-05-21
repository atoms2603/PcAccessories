using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcAccessories.Dtos.InvoiceDto;
using PcAccessories.Entities.Entities;
using PcAccessories.Services.InvoiceDetailService;
using PcAccessories.Services.InvoiceService;
using PcAccessories.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.Cms.InvoiceAPI
{
    [Route("cms/api/invoice")]
    [ApiController]
    public class InvoiceController : APIControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IProductService _productService;

        public InvoiceController(IInvoiceService invoiceService,
            IInvoiceDetailService invoiceDetailService,
            IProductService productService)
        {
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
            _productService = productService;
        }

        [HttpGet("get-list-order")]
        public async Task<IActionResult> GetListOrder()
        {
            var currentUserLoginId = this.UserId.Value;

            var listInvoice = await _invoiceService.GetInvoiceByUserIdAsync(currentUserLoginId);
            if (!listInvoice.Any())
            {
                return BadRequest("Do not have any Invoice.");
            }

            return Ok(listInvoice);
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceDetail(Guid invoiceId)
        {
            var currentUserLoginId = this.UserId.Value;

            var invoiceDetail = from invoice in _invoiceService.GetAllQuery()
                              join detail in _invoiceDetailService.GetAllQuery() on invoice.InvoiceId equals detail.InvoiceId
                              where invoice.InvoiceId == invoiceId
                              select new InvoiceDetailResponseDto
                              {
                                  DeliveryName = invoice.DeliveryName,
                                  DeliveryAddress = invoice.DeliveryAddress,
                                  DeliveryPhone = invoice.DeliveryPhone,
                                  Products = (from product in _productService.GetAllQuery()
                                              where detail.ProductId == product.ProductId
                                              select new InvoiceDetailResponseDto.Product
                                              {
                                                  ProductId = product.ProductId,
                                                  ProductName = product.Name,
                                                  Quantity = detail.Quantity,
                                                  Price = detail.Price
                                              }).ToList()
                              };
            if (invoiceDetail == null)
            {
                return BadRequest();
            }

            return Ok(invoiceDetail);
        }

        [HttpPost("create-invoice")]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceRequestDto dto)
        {
            var currentUserLoginId = this.UserId.Value;

            var invoice = new Invoice
            {
                InvoiceId = Guid.NewGuid(),
                CreatetionTime = DateTime.Now,
                CreatetionBy = currentUserLoginId,
                DeliveryName = dto.DeliveryName,
                DeliveryAddress = dto.DeliveryAddress,
                DeliveryPhone = dto.DeliveryPhone
            };
            await _invoiceService.InsertAsync(invoice);
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>();

            dto.Products.ForEach(x => {
                var invoiceDetail = new InvoiceDetail
                {
                    InvoiceDetailId = Guid.NewGuid(),
                    InvoiceId = invoice.InvoiceId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = x.Price
                };
                invoiceDetails.Add(invoiceDetail);
            });

            await _invoiceDetailService.BulkInsertAsync(invoiceDetails);

            return Ok();
        }
    }
}
