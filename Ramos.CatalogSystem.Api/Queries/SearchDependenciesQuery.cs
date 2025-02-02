using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using System.Collections.Generic;

namespace Ramos.CatalogSystem.Api.Queries
{
    public class SearchDependenciesQuery : IRequest<ApiResponse<IEnumerable<Dependency>>>
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string License { get; set; } = string.Empty;
        public string DocumentationLink { get; set; } = string.Empty;
    }
}