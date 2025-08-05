using BloggerBits.DTOS.Requests;
using BloggerBits.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace BloggerBits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("save-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequest request)
        {
            var resp = await _categoryService.SaveCategoryAsync(request);
            return Ok(resp);
        }
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequest request)
        {
            var resp = await _categoryService.UpdateCategoryAsync(id, request);
            return Ok(resp);
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            var resp = await _categoryService.GetCategoryAsync(id);
            return Ok(resp);
        }
        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategoryAsync(int id, bool status)
        {
            var resp = await _categoryService.DeleteCategory(id, status);
            return Ok(resp);
        }
    }
}
