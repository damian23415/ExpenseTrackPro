using ExpenseTrackPro.Application.DTOs.Categories;
using ExpenseTrackPro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackProV2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }
    
    [HttpGet("{categoryId}")]
    public async Task<ActionResult<CategoryDTO>> GetCategoryById(int categoryId)
    {
        var result = await _categoryService.GetCategoryByIdAsync(categoryId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
    {
        await _categoryService.CreateCategoryAsync(categoryDTO);
        return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDTO.CategoryId }, categoryDTO);
    }
}