using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Commands.Handlers;

public class CreateDependencyCommandHandler : IRequestHandler<CreateDependencyCommand, ApiResponse<Dependency>>
{
    private readonly MongoDBContext _context;

    public CreateDependencyCommandHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<Dependency>> Handle(CreateDependencyCommand request, CancellationToken cancellationToken)
    {
        var dependency = new Dependency
        {
            Name = request.Name,
            Version = request.Version,
            License = request.License,
            DocumentationLink = request.DocumentationLink,
            Provider = request.Provider
        };
        
        await _context.Dependencies.InsertOneAsync(dependency, cancellationToken: cancellationToken);
        
        return new ApiResponse<Dependency>
        {
            Data = dependency,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Dependency created successfully",
            StatusCode = 200
        };
        
    }
}