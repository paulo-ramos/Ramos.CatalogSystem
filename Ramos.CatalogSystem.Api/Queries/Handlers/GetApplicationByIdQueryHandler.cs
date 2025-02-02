using MediatR;
using MongoDB.Driver;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using Ramos.CatalogSystem.Api.Services.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Ramos.CatalogSystem.Api.Queries.Handlers
{
    public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, ApiResponse<Application>>
    {
        private readonly MongoDBContext _context;

        public GetApplicationByIdQueryHandler(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<Application>> Handle(GetApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            var application = await _context.Applications.Find(app => app.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (application == null)
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

            return new ApiResponse<Application>
            {
                Data = application,
                Success = true,
                RequestDate = DateTime.UtcNow,
                Message = "Application retrieved successfully",
                StatusCode = 200
            };
        }
    }
}