using MongoDB.Bson;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Services.Context;
using Ramos.CatalogSystem.Api.Services.Interfaces;

namespace Ramos.CatalogSystem.Api.Services
{
    public class SoftwareService : ISoftwareService
    {
        private readonly IMongoCollection<Software> _softwares;

        public SoftwareService(MongoDBContext context)
        {
            _softwares = context.Softwares;
        }

        public async Task<IEnumerable<Software>> GetAllSoftwaresAsync()
        {
            return await _softwares.Find(soft => true).ToListAsync();
        }

        public async Task<Software> GetSoftwareByIdAsync(string id)
        {
            return await _softwares.Find(soft => soft.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateSoftwareAsync(Software software)
        {
            await _softwares.InsertOneAsync(software);
        }

        public async Task UpdateSoftwareAsync(string id, Software software)
        {
            await _softwares.ReplaceOneAsync(soft => soft.Id == id, software);
        }

        public async Task DeleteSoftwareAsync(string id)
        {
            await _softwares.DeleteOneAsync(soft => soft.Id == id);
        }
    }
}