using ExpenseTraackPro.Domain.Entities;
using ExpenseTrackPro.Application.Interfaces.IRepository;
using ExpenseTrackPro.Infrastructure.Context;

namespace ExpenseTrackPro.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Category> AddCategoryAsync(Category category)
    {
        await _context.Category.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }
}