using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Queries;

public class GetSoftwareByIdQuery : IRequest<ApiResponse<Software>>
{
    public string Id { get; set; }

    public GetSoftwareByIdQuery(string id)
    {
        Id = id;
    }
}