using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Queries;

public class GetAllInfrastructuresQuery : IRequest<ApiResponse<IEnumerable<Infrastructure>>>
{
    
}