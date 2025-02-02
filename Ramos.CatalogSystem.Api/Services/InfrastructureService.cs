using MongoDB.Bson;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Services.Context;
using Ramos.CatalogSystem.Api.Services.Interfaces;

namespace Ramos.CatalogSystem.Api.Services
{
    public class InfrastructureService : IInfrastructureService
    {
        private readonly IMongoCollection<Infrastructure> _infrastructures;

        public InfrastructureService(MongoDBContext context)
        {
            _infrastructures = context.Infrastructures;
        }

        public async Task<IEnumerable<Infrastructure>> GetAllInfrastructuresAsync()
        {
            return await _infrastructures.Find(inf => true).ToListAsync();
        }

        public async Task<Infrastructure> GetInfrastructureByIdAsync(string id)
        {
            return await _infrastructures.Find(inf => inf.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateInfrastructureAsync(Infrastructure infrastructure)
        {
            await _infrastructures.InsertOneAsync(infrastructure);
        }

        public async Task UpdateInfrastructureAsync(string id, Infrastructure infrastructure)
        {
            await _infrastructures.ReplaceOneAsync(inf => inf.Id == id, infrastructure);
        }

        public async Task DeleteInfrastructureAsync(string id)
        {
            await _infrastructures.DeleteOneAsync(inf => inf.Id == id);
        }
    }
}