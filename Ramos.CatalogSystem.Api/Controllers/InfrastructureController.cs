using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ramos.CatalogSystem.Api.Commands;
using Ramos.CatalogSystem.Api.Queries;
using Ramos.CatalogSystem.Api.Responses;

namespace Ramos.CatalogSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfrastructureController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InfrastructureController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        
        private ObjectResult CreateResponse<T>(ApiResponse<T> response)
        {
            response.TraceId = _httpContextAccessor.HttpContext?.TraceIdentifier;
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllInfrastructuresQuery());
            return CreateResponse(response);
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchInfrastructuresQuery query)
        {
            var response = await _mediator.Send(query);
            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateInfraestructureCommand command)
        {
            var response = await _mediator.Send(command);
            return CreateResponse(response);
        }

        
    }
}