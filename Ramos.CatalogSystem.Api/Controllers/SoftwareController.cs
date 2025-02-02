using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ramos.CatalogSystem.Api.Commands;
using Ramos.CatalogSystem.Api.Responses;
using System.Threading.Tasks;
using Ramos.CatalogSystem.Api.Queries;
using Ramos.CatalogSystem.Api.Requests.Commands;

namespace Ramos.CatalogSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftwareController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SoftwareController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
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
            var response = await _mediator.Send(new GetAllSoftwaresQuery());
            return CreateResponse(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _mediator.Send(new GetSoftwareByIdQuery(id));
            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSoftwareCommand command)
        {
            var response = await _mediator.Send(command);
            return CreateResponse(response);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateSoftwareCommand command)
        {
            var response = await _mediator.Send(new UpdateSoftwareRequest(id, command));
            return CreateResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new DeleteSoftwareCommand(id));
            return CreateResponse(response);
        }
    }
}