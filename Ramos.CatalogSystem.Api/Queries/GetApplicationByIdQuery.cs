using MediatR;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Queries
{
    public class GetApplicationByIdQuery : IRequest<ApiResponse<Application>>
    {
        public string Id { get; set; }

        public GetApplicationByIdQuery(string id)
        {
            Id = id;
        }
    }
}