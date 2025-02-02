using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;

namespace Ramos.CatalogSystem.Api.Commands.Handlers;

public class CreateInfrastructureCommandHandler : IRequestHandler<CreateInfraestructureCommand, ApiResponse<Infrastructure>>
{
    private readonly MongoDBContext _context;

    public CreateInfrastructureCommandHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<Infrastructure>> Handle(CreateInfraestructureCommand request, CancellationToken cancellationToken)
    {
        var infraestructure = new Infrastructure
        {
            Type = request.Type,
            Location = request.Location,
            Specifications = request.Specifications,
            Responsible = request.Responsible
        };
        
        await _context.Infrastructures.InsertOneAsync(infraestructure, cancellationToken: cancellationToken);

        return new ApiResponse<Infrastructure>()
        {
            Data = infraestructure,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Infrastructure created successfully",
            StatusCode = 200
        };
    }
}