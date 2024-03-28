using ExpenseTrackPro.Application.DTOs.Categories;
using ExpenseTrackPro.Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackProV2.Controllers;

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }
    
    [HttpPost("Authentication")]
    public async Task<IActionResult> Authentication(AddCategoryRequest categoryModel, CancellationToken cancellationToken)
    {
        var result = await _categoryService.AddCategoryAsync(categoryModel);

        return Ok(result);
    }
}