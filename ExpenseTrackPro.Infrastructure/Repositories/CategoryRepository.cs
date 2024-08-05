using ExpenseTraackPro.Domain.Entities;
using ExpenseTraackPro.Domain.Interfaces;
using ExpenseTrackPro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackPro.Infrastructure.Repositories;

public class CategoryRepository : IRepository<Category>
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Category> _categories;


    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _categories = context.Set<Category>();
    }

    public async Task AddAsync(Category entity)
    {
        await _categories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _categories.FindAsync(id);
        if (entity != null)
        {
            _categories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categories.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _categories.FindAsync(id);
    }

    public async Task UpdateAsync(Category entity)
    {
        _categories.Update(entity);
        await _context.SaveChangesAsync();
    }
}
