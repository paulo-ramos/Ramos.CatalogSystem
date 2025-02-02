using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Ramos.CatalogSystem.Api.Models.Base;

namespace Ramos.CatalogSystem.Api.Models;

public class Application : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Responsible { get; set; } = string.Empty;
}
