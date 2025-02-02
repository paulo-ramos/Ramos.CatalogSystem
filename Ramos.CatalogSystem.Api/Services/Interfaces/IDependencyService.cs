using MongoDB.Bson;
using Ramos.CatalogSystem.Api.Models;

namespace Ramos.CatalogSystem.Api.Services.Interfaces;

public interface IDependencyService
{
    Task<IEnumerable<Dependency>> GetAllDependenciesAsync();
    Task<Dependency> GetDependencyByIdAsync(string id);
    Task CreateDependencyAsync(Dependency dependency);
    Task UpdateDependencyAsync(string id, Dependency dependency);
    Task DeleteDependencyAsync(string id);
}
