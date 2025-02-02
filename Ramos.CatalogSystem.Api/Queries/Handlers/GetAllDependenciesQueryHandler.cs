using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Queries.Handlers;

public class GetAllDependenciesQueryHandler : IRequestHandler<GetAllDependenciesQuery, ApiResponse<IEnumerable<Dependency>>>
{
    private readonly MongoDBContext _context;

    public GetAllDependenciesQueryHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<IEnumerable<Dependency>>> Handle(GetAllDependenciesQuery request, CancellationToken cancellationToken)
    {
        var dependencies = await _context.Dependencies.Find(app => true).ToListAsync(cancellationToken: cancellationToken);

        return new ApiResponse<IEnumerable<Dependency>>
        {
            Data = dependencies,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Dependencies retrieved successfully",
            StatusCode = 200
        };

    }
}