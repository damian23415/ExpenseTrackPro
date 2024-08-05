using AutoMapper;
using ExpenseTraackPro.Domain.Entities;
using ExpenseTraackPro.Domain.Interfaces;
using ExpenseTrackPro.Application.DTOs.Categories;
using ExpenseTrackPro.Application.Interfaces;

namespace ExpenseTrackPro.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task CreateCategoryAsync(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.AddAsync(category);
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        return _mapper.Map<CategoryDTO>(category);
    }
}