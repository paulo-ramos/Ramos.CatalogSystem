using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Queries.Handlers;

public class SearchInfrastructuresQueryHandler : IRequestHandler<SearchInfrastructuresQuery, ApiResponse<IEnumerable<Infrastructure>>>
{
    private readonly MongoDBContext _context;

    public SearchInfrastructuresQueryHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<IEnumerable<Infrastructure>>> Handle(SearchInfrastructuresQuery request, CancellationToken cancellationToken)
    {
        var filterBuilder = Builders<Infrastructure>.Filter;
        var filter = filterBuilder.Empty;

        if (!string.IsNullOrEmpty(request.Type))
        {
            filter &= filterBuilder.Eq(infrastructure => infrastructure.Type, request.Type);
        }
        if (!string.IsNullOrEmpty(request.Specifications))
        {
            filter &= filterBuilder.Eq(infrastructure => infrastructure.Specifications, request.Specifications);
        }
        if (!string.IsNullOrEmpty(request.Location))
        {
            filter &= filterBuilder.Eq(infrastructure => infrastructure.Location, request.Location);
        }
        if (!string.IsNullOrEmpty(request.Responsible))
        {
            filter &= filterBuilder.Eq(infrastructure => infrastructure.Responsible, request.Responsible);
        }

        var infrastructures = await _context.Infrastructures.Find(filter).ToListAsync(cancellationToken: cancellationToken);

        return new ApiResponse<IEnumerable<Infrastructure>>
        {
            Success = true,
            StatusCode = 200,
            RequestDate = DateTime.UtcNow,
            Message = "Infrastructures retrieved successfully",
            Data = infrastructures
        };
    }
}