using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Commands;

public class DeleteSoftwareCommand : IRequest<ApiResponse<string>>
{
    public string Id { get; set; }

    public DeleteSoftwareCommand(string id)
    {
        Id = id;
    }
}
