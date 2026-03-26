using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Api.Models.Dtos;

public class UpdateShoppingItemDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Quantity { get; set; }

    [Required]
    [MaxLength(20)]
    public string Unit { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = string.Empty;

    public bool IsPurchased { get; set; }

    [MaxLength(250)]
    public string? Note { get; set; }
}