using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShoppingList.Api.Models.Domain;
using ShoppingList.Api.Settings;

namespace ShoppingList.Api.Services;

public class ShoppingItemsService
{
    private readonly IMongoCollection<ShoppingItem> _shoppingItemsCollection;

    public ShoppingItemsService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

        _shoppingItemsCollection = mongoDatabase.GetCollection<ShoppingItem>(
            mongoDbSettings.Value.ShoppingItemsCollectionName);
    }

    public async Task<List<ShoppingItem>> GetByListIdAsync(string listId) =>
        await _shoppingItemsCollection.Find(x => x.ListId == listId).ToListAsync();

    public async Task<ShoppingItem?> GetByIdAsync(string id) =>
        await _shoppingItemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ShoppingItem shoppingItem) =>
        await _shoppingItemsCollection.InsertOneAsync(shoppingItem);

    public async Task UpdateAsync(string id, ShoppingItem updatedShoppingItem) =>
        await _shoppingItemsCollection.ReplaceOneAsync(x => x.Id == id, updatedShoppingItem);

    public async Task DeleteAsync(string id) =>
        await _shoppingItemsCollection.DeleteOneAsync(x => x.Id == id);

    public async Task DeleteByListIdAsync(string listId) =>
        await _shoppingItemsCollection.DeleteManyAsync(x => x.ListId == listId);
}