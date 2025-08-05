using System;
using AutoMapper;
using BloggerBits.DTOS.Requests;
using BloggerBits.DTOS.Responses.Categories;
using BloggerBits.Entities;
using BloggerBits.Exceptions;
using BloggerBits.Helper;
using BloggerBits.Repositories.Categories;

namespace BloggerBits.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;

    }

    public async Task<bool> DeleteCategory(int id, bool status)
    {
        var categoryRefference = await _categoryRepository.GetByIdAsync(id);
        if (categoryRefference is null)
        {
            Exception exception = new Exception("Category not found");
            throw exception;
        }
        categoryRefference.isActive = status;

        var resp = _mapper.Map<Category>(categoryRefference);
        await _categoryRepository.UpdateAsync(resp);
        await _categoryRepository.SaveChangesAsync();
        return true;

    }

    public async Task<CategoryResponse> GetCategoryAsync(int id)
    {
        var resp = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryResponse>(resp);

    }

    public async Task<bool> SaveCategoryAsync(CategoryRequest request)
    {
        try
        {
            var categoryRef = _mapper.Map<Category>(request);
            var resp = await _categoryRepository.AddAsync(categoryRef);
            if (resp is null)
            {
                Exception exception = new OperationFailedException("Error Saving Category");
                throw exception;
            }
            return true;
        }
        catch (Exception ex)
        {
            Exception exception = new OperationFailedException("Error Saving Category", ex);
            throw exception;
        }
    }

    public async Task<bool> UpdateCategoryAsync(int id, CategoryRequest request)
    {
        var alreadyTuned = await _categoryRepository.RecordExistsAsync(x => x.Id != id && x.Name == request.Name);
        if (alreadyTuned)
        {
            Exception exception = new RecordAlreadyExistsException(UiMessage.RECORD_EXISTS);
            throw exception;
        }
        var categoryRef = await _categoryRepository.GetByIdAsync(id);
        var categoryEntity = _mapper.Map<Category>(categoryRef);
        var updated = _categoryRepository.UpdateAsync(categoryEntity);
        await _categoryRepository.SaveChangesAsync();
        return true;
    }
}
