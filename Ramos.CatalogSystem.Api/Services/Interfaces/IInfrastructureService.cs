using MongoDB.Bson;
using Ramos.CatalogSystem.Api.Models;

namespace Ramos.CatalogSystem.Api.Services.Interfaces
{
    public interface IInfrastructureService
    {
        Task<IEnumerable<Infrastructure>> GetAllInfrastructuresAsync();
        Task<Infrastructure> GetInfrastructureByIdAsync(string id);
        Task CreateInfrastructureAsync(Infrastructure infrastructure);
        Task UpdateInfrastructureAsync(string id, Infrastructure infrastructure);
        Task DeleteInfrastructureAsync(string id);
    }
}