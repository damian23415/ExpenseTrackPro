using System.Net;
using ExpenseTraackPro.Domain.Entities;
using ExpenseTrackPro.Application.DTOs.Categories;
using ExpenseTrackPro.Application.Interfaces.IRepository;
using ExpenseTrackPro.Application.Interfaces.IService;
using ExpenseTrackPro.Application.Wrappers;

namespace ExpenseTrackPro.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }
    
    public async Task<ApiResponse<Category>> AddCategoryAsync(AddCategoryRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return new ApiResponse<Category>($"Parameter {nameof(request.Name)} can't be null",
                HttpStatusCode.BadRequest);
        
        var category = new Category
        {
            CategoryName = request.Name
        };

        await _categoryRepository.AddCategoryAsync(category);

        return new ApiResponse<Category>(category, "Category added");
    }
}