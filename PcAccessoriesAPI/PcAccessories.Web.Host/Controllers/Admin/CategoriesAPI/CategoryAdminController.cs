using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcAccessories.Dtos.CategoryDto.Request;
using PcAccessories.Dtos.CategoryDto.Response;
using PcAccessories.Dtos.Pagination;
using PcAccessories.Entities.Entities;
using PcAccessories.Services.BrandService;
using PcAccessories.Services.CategoryService;
using PcAccessories.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAccessories.WebAPI.Controllers.Admin.CategoriesAPI
{
    [Route("admin/api/category")]
    [ApiController]
    public class CategoryAdminController : APIControllerBase
    {
        #region Private fields

        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        #endregion

        #region Constructor

        public CategoryAdminController(ICategoryService categoryService,
            IBrandService brandService)
        {
            _categoryService = categoryService;
            _brandService = brandService;
        }

        #endregion

        #region API Controllers

        [HttpGet]
        public async Task<IActionResult> GetListcategory([FromQuery] GetListCategoryRequestDto request)
        {
            var categoryQuery = from category in _categoryService.GetAllQuery()
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
                               };

            if (!string.IsNullOrEmpty(request.Keyword))
                categoryQuery = categoryQuery.Where(x => x.Name.Contains(request.Keyword));

            // Count rows
            int totalRowsFound = await categoryQuery.CountAsync();
            if (totalRowsFound == 0) return Ok(new PagingResult<GetListCategoryResponseDto>(null, 0, request.PageIndex, request.PageSize));

            // Apply Sort
            categoryQuery = ApplySort(categoryQuery, request.SortBy, request.SortOrder);

            // Pagination
            var pageResult = await categoryQuery.Skip(request.Offset).Take(request.PageSize).ToListAsync();

            return Ok(new PagingResult<GetListCategoryResponseDto>(pageResult, totalRowsFound, request.PageIndex, request.PageSize));
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var categoryEntity = await _categoryService.GetCategoryById(categoryId);
            if (categoryEntity == null)
                return BadRequest(ErrorMessages.Category_NotFound);

            return Ok(categoryEntity);
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = request.Name
            };

            await _categoryService.InsertAsync(newCategory);
            return Ok();
        }

        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var categoryEntity = await _categoryService.GetCategoryById(categoryId);
            if (categoryEntity == null)
                return BadRequest(ErrorMessages.Category_NotFound);

            await _categoryService.DeleteAsync(categoryEntity);

            return Ok();
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> Updatecategory(UpdateCategoryRequestDto request)
        {
            var categoryEntity = await _categoryService.GetCategoryById(request.CategoryId);
            if (categoryEntity == null)
                return BadRequest(ErrorMessages.Category_NotFound);

            var isModified = false;

            if (request.Name != categoryEntity.Name)
            {
                categoryEntity.Name = request.Name;
                isModified = true;
            }

            if (isModified)
            {
                await _categoryService.UpdateAsync(categoryEntity);
            }

            return Ok(categoryEntity);
        }

        #endregion

        #region Private methods

        private IQueryable<GetListCategoryResponseDto> ApplySort(IQueryable<GetListCategoryResponseDto> query, string sortColumn, string sortOrder)
        {
            return (sortColumn?.ToLower()) switch
            {
                "name" => "desc" == sortOrder ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name),
                _ => query.OrderByDescending(x => x.Name),
            };
        }

        #endregion
    }
}
