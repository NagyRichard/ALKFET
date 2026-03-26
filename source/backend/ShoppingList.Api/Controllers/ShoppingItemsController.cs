using Microsoft.AspNetCore.Mvc;
using ShoppingList.Api.Models.Domain;
using ShoppingList.Api.Models.Dtos;
using ShoppingList.Api.Services;

namespace ShoppingList.Api.Controllers;

[ApiController]
[Route("api/lists/{listId:length(24)}/items")]
public class ShoppingItemsController : ControllerBase
{
    private readonly ShoppingListsService _shoppingListsService;
    private readonly ShoppingItemsService _shoppingItemsService;

    public ShoppingItemsController(
        ShoppingListsService shoppingListsService,
        ShoppingItemsService shoppingItemsService)
    {
        _shoppingListsService = shoppingListsService;
        _shoppingItemsService = shoppingItemsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShoppingItem>>> GetByListId(string listId)
    {
        var shoppingList = await _shoppingListsService.GetAsync(listId);

        if (shoppingList is null)
        {
            return NotFound("Shopping list not found.");
        }

        var items = await _shoppingItemsService.GetByListIdAsync(listId);
        return Ok(items);
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingItem>> Create(string listId, CreateShoppingItemDto dto)
    {
        var shoppingList = await _shoppingListsService.GetAsync(listId);

        if (shoppingList is null)
        {
            return NotFound("Shopping list not found.");
        }

        var item = new ShoppingItem
        {
            ListId = listId,
            Name = dto.Name,
            Quantity = dto.Quantity,
            Unit = dto.Unit,
            Category = dto.Category,
            Note = dto.Note,
            IsPurchased = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _shoppingItemsService.CreateAsync(item);

        return CreatedAtAction(nameof(GetByListId), new { listId }, item);
    }

    [HttpPut("{itemId:length(24)}")]
    public async Task<IActionResult> Update(string listId, string itemId, UpdateShoppingItemDto dto)
    {
        var shoppingList = await _shoppingListsService.GetAsync(listId);

        if (shoppingList is null)
        {
            return NotFound("Shopping list not found.");
        }

        var existingItem = await _shoppingItemsService.GetByIdAsync(itemId);

        if (existingItem is null || existingItem.ListId != listId)
        {
            return NotFound("Shopping item not found.");
        }

        existingItem.Name = dto.Name;
        existingItem.Quantity = dto.Quantity;
        existingItem.Unit = dto.Unit;
        existingItem.Category = dto.Category;
        existingItem.Note = dto.Note;
        existingItem.IsPurchased = dto.IsPurchased;
        existingItem.UpdatedAt = DateTime.UtcNow;

        await _shoppingItemsService.UpdateAsync(itemId, existingItem);

        return NoContent();
    }

    [HttpPatch("{itemId:length(24)}/toggle")]
    public async Task<IActionResult> TogglePurchased(string listId, string itemId)
    {
        var existingItem = await _shoppingItemsService.GetByIdAsync(itemId);

        if (existingItem is null || existingItem.ListId != listId)
        {
            return NotFound("Shopping item not found.");
        }

        existingItem.IsPurchased = !existingItem.IsPurchased;
        existingItem.UpdatedAt = DateTime.UtcNow;

        await _shoppingItemsService.UpdateAsync(itemId, existingItem);

        return NoContent();
    }

    [HttpDelete("{itemId:length(24)}")]
    public async Task<IActionResult> Delete(string listId, string itemId)
    {
        var existingItem = await _shoppingItemsService.GetByIdAsync(itemId);

        if (existingItem is null || existingItem.ListId != listId)
        {
            return NotFound("Shopping item not found.");
        }

        await _shoppingItemsService.DeleteAsync(itemId);

        return NoContent();
    }
}