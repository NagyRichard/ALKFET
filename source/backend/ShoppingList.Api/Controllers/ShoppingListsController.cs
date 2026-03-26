using Microsoft.AspNetCore.Mvc;
using ShoppingList.Api.Models.Dtos;
using ShoppingList.Api.Services;
using ShoppingListEntity = ShoppingList.Api.Models.Domain.ShoppingList;

namespace ShoppingList.Api.Controllers;

[ApiController]
[Route("api/lists")]
public class ShoppingListsController : ControllerBase
{
    private readonly ShoppingListsService _shoppingListsService;
    private readonly ShoppingItemsService _shoppingItemsService;

    public ShoppingListsController(
        ShoppingListsService shoppingListsService,
        ShoppingItemsService shoppingItemsService)
    {
        _shoppingListsService = shoppingListsService;
        _shoppingItemsService = shoppingItemsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShoppingListEntity>>> Get()
    {
        var lists = await _shoppingListsService.GetAsync();
        return Ok(lists);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ShoppingListEntity>> Get(string id)
    {
        var shoppingList = await _shoppingListsService.GetAsync(id);

        if (shoppingList is null)
        {
            return NotFound();
        }

        return Ok(shoppingList);
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingListEntity>> Create(CreateShoppingListDto dto)
    {
        var shoppingList = new ShoppingListEntity
        {
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _shoppingListsService.CreateAsync(shoppingList);

        return CreatedAtAction(nameof(Get), new { id = shoppingList.Id }, shoppingList);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, UpdateShoppingListDto dto)
    {
        var existingShoppingList = await _shoppingListsService.GetAsync(id);

        if (existingShoppingList is null)
        {
            return NotFound();
        }

        existingShoppingList.Name = dto.Name;
        existingShoppingList.UpdatedAt = DateTime.UtcNow;

        await _shoppingListsService.UpdateAsync(id, existingShoppingList);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingShoppingList = await _shoppingListsService.GetAsync(id);

        if (existingShoppingList is null)
        {
            return NotFound();
        }

        await _shoppingItemsService.DeleteByListIdAsync(id);
        await _shoppingListsService.DeleteAsync(id);

        return NoContent();
    }
}