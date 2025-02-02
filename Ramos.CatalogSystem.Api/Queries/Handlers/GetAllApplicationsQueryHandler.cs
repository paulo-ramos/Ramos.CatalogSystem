using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Ramos.CatalogSystem.Api.Queries.Handlers;

public class
    GetAllApplicationsQueryHandler : IRequestHandler<GetAllApplicationsQuery, ApiResponse<IEnumerable<Application>>>
{
    private readonly MongoDBContext _context;

    public GetAllApplicationsQueryHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<IEnumerable<Application>>> Handle(GetAllApplicationsQuery request,
        CancellationToken cancellationToken)
    {
        var applications =
            await _context.Applications.Find(app => true).ToListAsync(cancellationToken: cancellationToken);
        return new ApiResponse<IEnumerable<Application>>
        {
            Data = applications,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Applications retrieved successfully",
            StatusCode = 200
        };
    }
}
