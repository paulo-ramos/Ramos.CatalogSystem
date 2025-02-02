using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ramos.CatalogSystem.Api.Requests.Commands;

namespace Ramos.CatalogSystem.Api.Commands.Handlers
{
    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationRequest, ApiResponse<Application>>
    {
        private readonly MongoDBContext _context;

        public UpdateApplicationCommandHandler(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<Application>> Handle(UpdateApplicationRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Application>.Filter.Eq(app => app.Id, request.Id);
            var update = Builders<Application>.Update
                .Set(app => app.Name, request.Command.Name)
                .Set(app => app.Description, request.Command.Description)
                .Set(app => app.Version, request.Command.Version)
                .Set(app => app.Responsible, request.Command.Responsible)
                .Set(app => app.UpdatedAt, DateTime.UtcNow);

            var result = await _context.Applications.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

            if (result.MatchedCount == 0)
            {
                return new ApiResponse<Application>
                {
                    Data = null,
                    Success = false,
                    RequestDate = DateTime.UtcNow,
                    Message = "Application not found",
                    StatusCode = 404
                };
            }

            var application = await _context.Applications.Find(app => app.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return new ApiResponse<Application>
            {
                Data = application,
                Success = true,
                RequestDate = DateTime.UtcNow,
                Message = "Application updated successfully",
                StatusCode = 200
            };
        }
    }
}