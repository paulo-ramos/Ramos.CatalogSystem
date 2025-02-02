using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using Ramos.CatalogSystem.Api.Models.Base;

namespace Ramos.CatalogSystem.Api.Models;

public class Infrastructure: Entity
{
    public string Type { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Responsible { get; set; } = string.Empty;
}