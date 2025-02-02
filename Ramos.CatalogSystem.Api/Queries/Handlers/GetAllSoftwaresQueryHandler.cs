using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Queries.Handlers;

public class GetAllSoftwaresQueryHandler : IRequestHandler<GetAllSoftwaresQuery, ApiResponse<IEnumerable<Software>>>
{
    private readonly MongoDBContext _context;

    public GetAllSoftwaresQueryHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<IEnumerable<Software>>> Handle(GetAllSoftwaresQuery request, CancellationToken cancellationToken)
    {
        var softwares = await _context.Softwares.Find(sft => true).ToListAsync(cancellationToken: cancellationToken);
        return new ApiResponse<IEnumerable<Software>>()
        {
            Data = softwares,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Software's retrieved successfully",
            StatusCode = 200
        };
    }
}