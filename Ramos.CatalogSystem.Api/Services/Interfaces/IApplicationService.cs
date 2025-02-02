using MongoDB.Bson;
using Ramos.CatalogSystem.Api.Models;

namespace Ramos.CatalogSystem.Api.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(string id);
        Task CreateApplicationAsync(Application application);
        Task UpdateApplicationAsync(string id, Application application);
        Task DeleteApplicationAsync(string id);
    }
}