using ExpenseTraackPro.Domain.Entities;
using ExpenseTrackPro.Application.DTOs.Categories;
using ExpenseTrackPro.Application.Wrappers;

namespace ExpenseTrackPro.Application.Interfaces.IService;

public interface ICategoryService
{
    Task<ApiResponse<Category>> AddCategoryAsync(AddCategoryRequest request);
}