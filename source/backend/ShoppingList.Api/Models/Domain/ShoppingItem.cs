using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShoppingList.Api.Models.Domain;

public class ShoppingItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string ListId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public string Unit { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public bool IsPurchased { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}