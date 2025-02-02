using MediatR;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Commands
{
    public class DeleteApplicationCommand : IRequest<ApiResponse<string>>
    {
        public string Id { get; set; }

        public DeleteApplicationCommand(string id)
        {
            Id = id;
        }
    }
}