using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackPro.Application.DTOs.Categories;

public class AddCategoryRequest
{
    [Required]
    public string Name { get; set; }
}