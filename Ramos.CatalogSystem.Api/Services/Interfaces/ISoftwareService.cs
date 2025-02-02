using MongoDB.Bson;
using Ramos.CatalogSystem.Api.Models;

namespace Ramos.CatalogSystem.Api.Services.Interfaces
{
    public interface ISoftwareService
    {
        Task<IEnumerable<Software>> GetAllSoftwaresAsync();
        Task<Software> GetSoftwareByIdAsync(string id);
        Task CreateSoftwareAsync(Software software);
        Task UpdateSoftwareAsync(string id, Software software);
        Task DeleteSoftwareAsync(string id);
    }
}