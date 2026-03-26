using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShoppingList.Api.Models.Domain;
using ShoppingList.Api.Settings;
using ShoppingListEntity = ShoppingList.Api.Models.Domain.ShoppingList;

namespace ShoppingList.Api.Services;

public class ShoppingListsService
{
    private readonly IMongoCollection<ShoppingListEntity> _shoppingListsCollection;

    public ShoppingListsService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

        _shoppingListsCollection = mongoDatabase.GetCollection<ShoppingListEntity>(
            mongoDbSettings.Value.ShoppingListsCollectionName);
    }

    public async Task<List<ShoppingListEntity>> GetAsync() =>
        await _shoppingListsCollection.Find(_ => true).ToListAsync();

    public async Task<ShoppingListEntity?> GetAsync(string id) =>
        await _shoppingListsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ShoppingListEntity shoppingList) =>
        await _shoppingListsCollection.InsertOneAsync(shoppingList);

    public async Task UpdateAsync(string id, ShoppingListEntity updatedShoppingList) =>
        await _shoppingListsCollection.ReplaceOneAsync(x => x.Id == id, updatedShoppingList);

    public async Task DeleteAsync(string id) =>
        await _shoppingListsCollection.DeleteOneAsync(x => x.Id == id);
}