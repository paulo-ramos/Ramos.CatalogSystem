using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ramos.CatalogSystem.Api.Commands.Handlers;

public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, ApiResponse<Application>>
{
    private readonly MongoDBContext _context;

    public CreateApplicationCommandHandler(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<Application>> Handle(CreateApplicationCommand request,
        CancellationToken cancellationToken)
    {
        var application = new Application
        {
            Name = request.Name,
            Description = request.Description,
            Version = request.Version,
            Responsible = request.Responsible
        };

        await _context.Applications.InsertOneAsync(application, cancellationToken: cancellationToken);
        return new ApiResponse<Application>
        {
            Data = application,
            Success = true,
            RequestDate = DateTime.UtcNow,
            Message = "Application created successfully",
            StatusCode = 200
        };
    }
}
