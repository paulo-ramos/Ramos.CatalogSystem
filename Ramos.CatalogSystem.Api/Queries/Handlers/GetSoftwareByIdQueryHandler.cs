using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Queries.Handlers;

public class GetSoftwareByIdQueryHandler : IRequestHandler<GetSoftwareByIdQuery, ApiResponse<Software>>
{
    private readonly MongoDBContext _context;

    public GetSoftwareByIdQueryHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<Software>> Handle(GetSoftwareByIdQuery request, CancellationToken cancellationToken)
    {
        var software = await _context.Softwares.Find(soft => soft.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (software == null)
        {
            return new ApiResponse<Software>
            {
                Data = null,
                Success = false,
                RequestDate = DateTime.UtcNow,
                Message = "Software not found",
                StatusCode = 404
            };
        }

        return new ApiResponse<Software>
        {
            Data = software,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Software retrieved successfully",
            StatusCode = 200
        };
    }
}