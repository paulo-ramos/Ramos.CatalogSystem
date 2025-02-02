using DnsClient.Protocol;
using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Requests.Commands;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Commands.Handlers;

public class UpdateSoftwareCommandHandler : IRequestHandler<UpdateSoftwareRequest, ApiResponse<Software>>
{
    private readonly MongoDBContext _context;

    public UpdateSoftwareCommandHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<Software>> Handle(UpdateSoftwareRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Software>.Filter.Eq(software => software.Id, request.Id);
        var update = Builders<Software>.Update
            .Set(software => software.Name, request.Command.Name)
            .Set(software => software.Version, request.Command.Version)
            .Set(software => software.License, request.Command.License)
            .Set(software => software.ReadmeLink, request.Command.ReadmeLink)
            .Set(software => software.ApplicationIds, request.Command.ApplicationIds)
            .Set(software => software.InfrastructureIds, request.Command.InfrastructureIds)
            .Set(software => software.DependencyIds, request.Command.DependencyIds)
            .Set(software => software.RelatedSoftwareIds, request.Command.RelatedSoftwareIds)
            .Set(software => software.UpdatedAt, DateTime.UtcNow); 

        var result = await _context.Softwares.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

        if (result.MatchedCount == 0)
        {
            return new ApiResponse<Software>
            {
                Success = false,
                StatusCode = 404,
                RequestDate = DateTime.UtcNow,
                Message = "Software not found",
                Data = null
            };
        }

        var software = await _context.Softwares.Find(software => software.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return new ApiResponse<Software>
        {
            Success = true,
            StatusCode = 200,
            RequestDate = DateTime.UtcNow,
            Message = "Software updated successfully",
            Data = software
        };
    }
}
