using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ramos.CatalogSystem.Api.Queries;
using Ramos.CatalogSystem.Api.Models;
using Ramos.CatalogSystem.Api.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ramos.CatalogSystem.Api.Commands;

namespace Ramos.CatalogSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependencyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DependencyController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
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
            var response = await _mediator.Send(new GetAllDependenciesQuery());
            return CreateResponse(response);
        }
        
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchDependenciesQuery query)
        {
            var response = await _mediator.Send(query);
            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDependencyCommand command)
        {
            var response = await _mediator.Send(command);
            return CreateResponse(response);
        }

        
    }
}