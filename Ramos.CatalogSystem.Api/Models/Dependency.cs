using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using Ramos.CatalogSystem.Api.Models.Base;

namespace Ramos.CatalogSystem.Api.Models;

public class Dependency : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string License { get; set; } = string.Empty;
    public string DocumentationLink { get; set; } = string.Empty;
}