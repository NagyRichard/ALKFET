using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShoppingList.Api.Models.Domain;

public class ShoppingList
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}