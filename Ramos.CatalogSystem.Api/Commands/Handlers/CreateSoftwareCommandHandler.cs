using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Commands.Handlers;

public class CreateSoftwareCommandHandler : IRequestHandler<CreateSoftwareCommand, ApiResponse<Software>>
{
    private readonly MongoDBContext _context;

    public CreateSoftwareCommandHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<Software>> Handle(CreateSoftwareCommand request, CancellationToken cancellationToken)
    {
        var software = new Software
        {
            Name = request.Name,
            Version = request.Version,
            License = request.License,
            ReadmeLink = request.ReadmeLink,
            ApplicationIds = request.ApplicationIds,
            InfrastructureIds = request.InfrastructureIds,
            DependencyIds = request.DependencyIds,
            RelatedSoftwareIds = request.RelatedSoftwareIds
        };

        await _context.Softwares.InsertOneAsync(software, cancellationToken: cancellationToken);
        return new ApiResponse<Software>
        {
            Data = software,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Software created successfully",
            StatusCode = 200
        };
    }
}