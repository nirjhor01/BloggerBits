using System;
using BloggerBits.DTOS.Requests;
using BloggerBits.DTOS.Responses.Categories;

namespace BloggerBits.Services.Categories;

public interface ICategoryService
{
    Task<bool> SaveCategoryAsync(CategoryRequest request);
    Task<bool> UpdateCategoryAsync(int id, CategoryRequest request);
    Task<CategoryResponse> GetCategoryAsync(int id);
    Task<bool> DeleteCategory(int id, bool status);
}
