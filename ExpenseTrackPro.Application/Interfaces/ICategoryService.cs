using ExpenseTraackPro.Domain.Entities;
using ExpenseTrackPro.Application.DTOs.Categories;

namespace ExpenseTrackPro.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryDTO> GetCategoryByIdAsync(int categoryId);
    Task CreateCategoryAsync(CategoryDTO categoryDTO);
}