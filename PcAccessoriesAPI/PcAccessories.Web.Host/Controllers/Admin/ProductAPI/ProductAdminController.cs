using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcAccessories.Dtos.Pagination;
using PcAccessories.Dtos.ProductDto.Request;
using PcAccessories.Dtos.ProductDto.Response;
using PcAccessories.Entities.Entities;
using PcAccessories.Services.ProductService;
using PcAccessories.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.Admin.ProductAPI
{
    [Route("admin/api/product")]
    [Authorize]
    [ApiController]
    public class ProductAdminController : APIControllerBase
    {
        #region Private fields

        private readonly IProductService _productService;

        #endregion

        #region Constructor

        public ProductAdminController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region API Controllers

        [HttpGet]
        public async Task<IActionResult> GetListProduct([FromQuery] GetListProductRequestDto request)
        {
            var productQuery = from product in _productService.GetAllQuery()
                               select new GetListProductResponseDto
                               {
                                   ProductId = product.ProductId,
                                   BrandId = Guid.Empty,
                                   Name = product.Name,
                                   Price = product.Price,
                                   Quantity = product.Quantity,
                                   Status = product.Status,
                                   ProductImages = null
                               };

            if (!string.IsNullOrEmpty(request.Keyword))
                productQuery = productQuery.Where(x => x.Name.Contains(request.Keyword));

            // Count rows
            int totalRowsFound = await productQuery.CountAsync();
            if (totalRowsFound == 0) return Ok(new PagingResult<GetListProductResponseDto>(null, 0, request.PageIndex, request.PageSize));

            // Apply Sort
            productQuery = ApplySort(productQuery, request.SortBy, request.SortOrder);

            // Pagination
            var pageResult = await productQuery.Skip(request.Offset).Take(request.PageSize).ToListAsync();

            return Ok(new PagingResult<GetListProductResponseDto>(pageResult, totalRowsFound, request.PageIndex, request.PageSize));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var productEntity = await _productService.GetProductById(productId);
            if (productEntity == null)
                return BadRequest(ErrorMessages.Product_NotFound);

            return Ok(productEntity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestDto request)
        {
            var newProduct = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreatetionTime = DateTime.UtcNow,
                CreatetionBy = Guid.Empty,
                Status = (byte)PcAccessoriesEnum.ProductStatus.New,
                BrandId = Guid.Empty
            };

            await _productService.InsertAsync(newProduct);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var productEntity = await _productService.GetProductById(productId);
            if (productEntity == null)
                return BadRequest(ErrorMessages.Product_NotFound);

            await _productService.DeleteAsync(productEntity);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestDto request)
        {
            var productEntity = await _productService.GetProductById(request.ProductId);
            if (productEntity == null)
                return BadRequest(ErrorMessages.Product_NotFound);

            var isModified = false;

            if (request.BrandId != productEntity.BrandId)
            {
                productEntity.BrandId = request.BrandId;
                isModified = true;
            }

            if (request.Name != productEntity.Name)
            {
                productEntity.Name = request.Name;
                isModified = true;
            }

            if (request.Price != productEntity.Price)
            {
                productEntity.Price = request.Price;
                isModified = true;
            }

            if (request.Quantity != productEntity.Quantity)
            {
                productEntity.Quantity = request.Quantity;
                isModified = true;
            }

            if (request.Status != productEntity.Status)
            {
                productEntity.Status = request.Status;
                isModified = true;
            }

            if (isModified)
            {
                await _productService.UpdateAsync(productEntity);
            }

            return Ok(productEntity);
        }

        #endregion

        #region Private methods

        private IQueryable<GetListProductResponseDto> ApplySort(IQueryable<GetListProductResponseDto> query, string sortColumn, string sortOrder)
        {
            return (sortColumn?.ToLower()) switch
            {
                "name" => "desc" == sortOrder ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name),
                "price" => "desc" == sortOrder ? query.OrderByDescending(x => x.Price) : query.OrderBy(x => x.Price),
                _ => query.OrderByDescending(x => x.Name),
            };
        }

        #endregion
    }
}
