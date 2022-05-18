using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcAccessories.Entities.Entities;
using PcAccessories.Services.BrandService;
using PcAccessories.Services.CartService;
using PcAccessories.Services.CategoryService;
using PcAccessories.Services.ProductInCartService;
using PcAccessories.Services.ProductService;
using PcAccessories.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.Cms.CartApi
{
    [Route("cms/api/cart")]
    [Authorize]
    [ApiController]
    public class CartController : APIControllerBase
    {
        #region Private fields

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICartService _cartService;
        private readonly IProductInCartService _productInCartService;
        #endregion

        #region Constructor

        public CartController(ICategoryService categoryService,
            IProductService productService,
            IBrandService brandService,
            ICartService cartService,
            IProductInCartService productInCartService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _brandService = brandService;
            _cartService = cartService;
            _productInCartService = productInCartService;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> AddProductToCart([Required]Guid productId, int quantity)
        {
            var currentUserLoginId = this.UserId.Value;
            var product = await _productService.GetProductById(productId);
            if(product == null)
            {
                return BadRequest(ErrorMessages.Product_NotFound);
            }

            var cart = await _cartService.GetByUserIdAsync(currentUserLoginId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = currentUserLoginId,
                    CartId = Guid.NewGuid()
                };
                await _cartService.InsertAsync(cart);
            }

            var productInCart = await _productInCartService.IsProductExistInCartAsync(cart.CartId, product.ProductId);
            if (productInCart != null)
            {
                productInCart.Quantity += quantity;
                await _productInCartService.UpdateAsync(productInCart);
            }
            else
            {
                await _productInCartService.InsertAsync(new ProductInCart
                {
                    CartId = cart.CartId,
                    ProductId = product.ProductId,
                    Quantity = quantity,
                    Price = product.Price,
                    ProductInCartId = Guid.NewGuid(),
                    CreatetionTime = DateTime.UtcNow,
                    CreatetionBy = currentUserLoginId
                });
            }
            

            return Ok();
        }

        
        [HttpGet("get-product-in-cart")]
        public async Task<IActionResult> GetCart()
        {
            var currentUserLoginId = this.UserId.Value;
            var cart = await _cartService.GetByUserIdAsync(currentUserLoginId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = currentUserLoginId,
                    CartId = Guid.NewGuid()
                };
                await _cartService.InsertAsync(cart);
            }

            var listProductInCart = (_productInCartService.GetAllQuery().Where(x => x.CartId == cart.CartId)).ToList();

            return Ok(listProductInCart);
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> DeleteProductInCart(Guid productId)
        {
            var currentUserLoginId = this.UserId.Value;
            var cart = await _cartService.GetByUserIdAsync(currentUserLoginId);
            var productInCart = await _productInCartService.IsProductExistInCartAsync(cart.CartId, productId);
            if (productInCart != null)
            {
                await _productInCartService.DeleteAsync(productInCart);
            }

            return Ok();
        }
    }
}
