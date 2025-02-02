using MediatR;
using Ramos.CatalogSystem.Api.Commands;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Requests.Commands
{
    public class UpdateApplicationRequest : IRequest<ApiResponse<Application>>
    {
        public string Id { get; set; }
        public UpdateApplicationCommand Command { get; set; }

        public UpdateApplicationRequest(string id, UpdateApplicationCommand command)
        {
            Id = id;
            Command = command;
        }
    }
}