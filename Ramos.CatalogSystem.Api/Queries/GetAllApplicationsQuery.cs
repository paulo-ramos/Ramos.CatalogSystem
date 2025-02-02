using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using System.Collections.Generic;

namespace Ramos.CatalogSystem.Api.Queries
{
    public class GetAllApplicationsQuery : IRequest<ApiResponse<IEnumerable<Application>>>
    {
    }
}