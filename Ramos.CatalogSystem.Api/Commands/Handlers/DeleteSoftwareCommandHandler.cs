using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Commands.Handlers;

public class DeleteSoftwareCommandHandler : IRequestHandler<DeleteSoftwareCommand, ApiResponse<string>>
{
    private readonly MongoDBContext _context;

    public DeleteSoftwareCommandHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<string>> Handle(DeleteSoftwareCommand request, CancellationToken cancellationToken)
    {
        var filter = Builders<Software>.Filter.Eq(soft => soft.Id, request.Id);
        var result = await _context.Softwares.DeleteOneAsync(filter, cancellationToken: cancellationToken);

        if (result.DeletedCount == 0)
        {
            return new ApiResponse<string>
            {
                Success = false,
                StatusCode = 404,
                RequestDate = DateTime.UtcNow,
                Message = "Software not found",
                Data = null
            };
        }

        return new ApiResponse<string>
        {
            Success = true,
            StatusCode = 200,
            RequestDate = DateTime.UtcNow,
            Message = "Software deleted successfully",
            Data = request.Id
        };
    }
}