using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;

namespace Ramos.CatalogSystem.Api.Services.Context;

public class MongoDBContext
{
    private readonly IMongoDatabase _database = null;

    public MongoDBContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
        if (client != null)
            _database = client.GetDatabase(configuration.GetSection("MongoDB:Database").Value);
    }

    public IMongoCollection<Application> Applications => _database.GetCollection<Application>("Applications");
    public IMongoCollection<Software> Softwares => _database.GetCollection<Software>("Softwares");

    public IMongoCollection<Infrastructure> Infrastructures =>
        _database.GetCollection<Infrastructure>("Infrastructures");

    public IMongoCollection<Dependency> Dependencies => _database.GetCollection<Dependency>("Dependencies");
}