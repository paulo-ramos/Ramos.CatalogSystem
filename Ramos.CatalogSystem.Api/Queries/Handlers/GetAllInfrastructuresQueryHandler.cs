using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ramos.CatalogSystem.Api.Queries.Handlers
{
    public class GetAllInfrastructuresQueryHandler : IRequestHandler<GetAllInfrastructuresQuery, ApiResponse<IEnumerable<Infrastructure>>>
    {
        private readonly MongoDBContext _context;

        public GetAllInfrastructuresQueryHandler(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<IEnumerable<Infrastructure>>> Handle(GetAllInfrastructuresQuery request, CancellationToken cancellationToken)
        {
            var infrastructures = await _context.Infrastructures.Find(_ => true).ToListAsync(cancellationToken: cancellationToken);

            return new ApiResponse<IEnumerable<Infrastructure>>
            {
                Data = infrastructures,
                Success = true,
                RequestDate = DateTime.UtcNow,
                Message = "Infrastructures retrieved successfully",
                StatusCode = 200
            };
        }
    }
}