namespace ShoppingList.Api.Settings;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string ShoppingListsCollectionName { get; set; } = string.Empty;
    public string ShoppingItemsCollectionName { get; set; } = string.Empty;
}