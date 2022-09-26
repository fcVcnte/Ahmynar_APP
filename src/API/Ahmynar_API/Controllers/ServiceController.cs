using Ahmynar_Application.DTOs.Service;
using Ahmynar_Application.Features.Service.Requests.Commands;
using Ahmynar_Application.Features.Service.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<ActionResult<List<ServiceListDto>>> GetAllServices()
        {
            var services = await _mediator.Send(new GetServicesListRequest());
            return services;
        }

        // GET api/<ServiceController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            var service = await _mediator.Send(new GetServiceDetailRequest { Id = id });
            return Ok(service);
        }

        // POST api/<ServiceController>
        [HttpPost]
        public async Task<ActionResult> PostService([FromBody] CreateServiceDto service)
        {
            var command = new CreateServiceCommand { ServiceDto = service };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ServiceController>/
        [HttpPut]
        public async Task<ActionResult> PutService([FromBody] UpdateServiceDto service)
        {
            var command = new UpdateServiceCommand { ServiceDto = service };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ServiceController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            var command = new DeleteServiceCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
