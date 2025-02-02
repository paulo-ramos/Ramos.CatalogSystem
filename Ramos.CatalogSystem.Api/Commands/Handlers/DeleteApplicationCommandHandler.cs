using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ramos.CatalogSystem.Api.Models;

namespace Ramos.CatalogSystem.Api.Commands.Handlers
{
    public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, ApiResponse<string>>
    {
        private readonly MongoDBContext _context;

        public DeleteApplicationCommandHandler(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<string>> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            var filter = Builders<Application>.Filter.Eq(app => app.Id, request.Id);
            var result = await _context.Applications.DeleteOneAsync(filter, cancellationToken: cancellationToken);

            if (result.DeletedCount == 0)
            {
                return new ApiResponse<string>
                {
                    Data = null,
                    Success = false,
                    RequestDate = DateTime.UtcNow,
                    Message = "Application not found",
                    StatusCode = 404
                };
            }

            return new ApiResponse<string>
            {
                Data = request.Id,
                Success = true,
                RequestDate = DateTime.UtcNow,
                Message = "Application deleted successfully",
                StatusCode = 200
            };
        }
    }
}