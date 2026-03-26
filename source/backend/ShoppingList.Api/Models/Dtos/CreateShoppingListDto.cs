using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Api.Models.Dtos;

public class CreateShoppingListDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}