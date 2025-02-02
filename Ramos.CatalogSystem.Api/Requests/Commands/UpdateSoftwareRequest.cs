using MediatR;
using Ramos.CatalogSystem.Api.Commands;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Requests.Commands;

public class UpdateSoftwareRequest : IRequest<ApiResponse<Software>>
{
    public string Id { get; set; }
    public UpdateSoftwareCommand Command { get; set; }

    public UpdateSoftwareRequest(string id, UpdateSoftwareCommand command)
    {
        Id = id;
        Command = command;
    }
    
}