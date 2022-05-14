using Microsoft.AspNetCore.Mvc;
using PcAccessories.Dtos.CategoryDto.Response;
using PcAccessories.Services.BrandService;
using PcAccessories.Services.CategoryService;
using System.Linq;

namespace PcAccessories.WebAPI.Controllers.Cms.CategoryAPI
{
    [Route("cms/api/category")]
    [ApiController]
    public class CategoryController : APIControllerBase
    {
        #region Private field
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        #endregion

        #region Constructor
        public CategoryController(ICategoryService categoryService,
            IBrandService brandService)
        {
            _categoryService = categoryService;
            _brandService = brandService;
        }
        #endregion

        #region API Controller
        [HttpGet]
        public IActionResult GetListCategory()
        {
            var listCategory = (from category in _categoryService.GetAllQuery()
                                select new GetListCategoryResponseDto
                                {
                                    CategoryId = category.CategoryId,
                                    Name = category.Name,
                                    Brands = (from brand in _brandService.GetAllQuery()
                                              where brand.CategoryId == category.CategoryId
                                              select new GetListCategoryResponseDto.Brand
                                              {
                                                  BrandId = brand.BrandId,
                                                  Name = brand.Name
                                              }).ToList()
                                }).ToList();
            return Ok(listCategory);
        }
        #endregion

        #region Private methods
        #endregion
    }
}
