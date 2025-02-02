using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ramos.CatalogSystem.Api.Models.Base;

public class Entity
{
    protected Entity()
    {
        Id = ObjectId.GenerateNewId().ToString();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}