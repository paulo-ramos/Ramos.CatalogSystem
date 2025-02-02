using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Commands;

public class CreateSoftwareCommand : IRequest<ApiResponse<Software>>
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string License { get; set; } = string.Empty;
    public string ReadmeLink { get; set; } = string.Empty;
    public List<string> ApplicationIds { get; set; } = new List<string>();
    public List<string> InfrastructureIds { get; set; } = new List<string>();
    public List<string> DependencyIds { get; set; } = new List<string>();
    public List<string> RelatedSoftwareIds { get; set; } = new List<string>();
}