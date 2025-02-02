using MongoDB.Bson;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Services.Context;
using Ramos.CatalogSystem.Api.Services.Interfaces;

namespace Ramos.CatalogSystem.Api.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IMongoCollection<Application> _applications;

        public ApplicationService(MongoDBContext context)
        {
            _applications = context.Applications;
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await _applications.Find(app => true).ToListAsync();
        }

        public async Task<Application> GetApplicationByIdAsync(string id)
        {
            return await _applications.Find(app => app.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateApplicationAsync(Application application)
        {
            await _applications.InsertOneAsync(application);
        }

        public async Task UpdateApplicationAsync(string id, Application application)
        {
            await _applications.ReplaceOneAsync(app => app.Id == id, application);
        }

        public async Task DeleteApplicationAsync(string id)
        {
            await _applications.DeleteOneAsync(app => app.Id == id);
        }
    }
}