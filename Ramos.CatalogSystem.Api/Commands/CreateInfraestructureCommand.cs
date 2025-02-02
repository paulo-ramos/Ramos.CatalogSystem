using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Commands;

public class CreateInfraestructureCommand : IRequest<ApiResponse<Infrastructure>>
{
    public string Type { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Responsible { get; set; } = string.Empty;
}