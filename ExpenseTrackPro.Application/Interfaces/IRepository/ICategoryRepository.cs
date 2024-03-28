using ExpenseTraackPro.Domain.Entities;

namespace ExpenseTrackPro.Application.Interfaces.IRepository;

public interface ICategoryRepository
{
    Task<Category> AddCategoryAsync(Category category);
}