using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ramos.CatalogSystem.Api.Queries.Handlers;

public class
    SearchDependenciesQueryHandler : IRequestHandler<SearchDependenciesQuery, ApiResponse<IEnumerable<Dependency>>>
{
    private readonly MongoDBContext _context;

    public SearchDependenciesQueryHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<IEnumerable<Dependency>>> Handle(SearchDependenciesQuery request,
        CancellationToken cancellationToken)
    {
        var filterBuilder = Builders<Dependency>.Filter;
        var filter = filterBuilder.Empty;

        if (!string.IsNullOrEmpty(request.Name))
        {
            filter &= filterBuilder.Eq(dep => dep.Name, request.Name);
        }

        if (!string.IsNullOrEmpty(request.Version))
        {
            filter &= filterBuilder.Eq(dep => dep.Version, request.Version);
        }

        if (!string.IsNullOrEmpty(request.Provider))
        {
            filter &= filterBuilder.Eq(dep => dep.Provider, request.Provider);
        }

        if (!string.IsNullOrEmpty(request.License))
        {
            filter &= filterBuilder.Eq(dep => dep.License, request.License);
        }

        if (!string.IsNullOrEmpty(request.DocumentationLink))
        {
            filter &= filterBuilder.Eq(dep => dep.DocumentationLink, request.DocumentationLink);
        }

        var dependencies = await _context.Dependencies.Find(filter).ToListAsync();

        return new ApiResponse<IEnumerable<Dependency>>
        {
            Success = true,
            StatusCode = 200,
            RequestDate = DateTime.UtcNow,
            Message = "Dependencies retrieved successfully",
            Data = dependencies
        };
    }
}

