using MongoDB.Bson;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Services.Context;
using Ramos.CatalogSystem.Api.Services.Interfaces;

namespace Ramos.CatalogSystem.Api.Services
{
    public class DependencyService : IDependencyService
    {
        private readonly IMongoCollection<Dependency> _dependencies;

        public DependencyService(MongoDBContext context)
        {
            _dependencies = context.Dependencies;
        }

        public async Task<IEnumerable<Dependency>> GetAllDependenciesAsync()
        {
            return await _dependencies.Find(dep => true).ToListAsync();
        }

        public async Task<Dependency> GetDependencyByIdAsync(string id)
        {
            return await _dependencies.Find(dep => dep.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateDependencyAsync(Dependency dependency)
        {
            await _dependencies.InsertOneAsync(dependency);
        }

        public async Task UpdateDependencyAsync(string id, Dependency dependency)
        {
            await _dependencies.ReplaceOneAsync(dep => dep.Id == id, dependency);
        }

        public async Task DeleteDependencyAsync(string id)
        {
            await _dependencies.DeleteOneAsync(dep => dep.Id == id);
        }
    }
}