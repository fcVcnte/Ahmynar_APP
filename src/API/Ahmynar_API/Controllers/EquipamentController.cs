using Ahmynar_Application.DTOs.Equipament;
using Ahmynar_Application.Features.Equipament.Requests.Commands;
using Ahmynar_Application.Features.Equipament.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EquipamentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EquipamentController>
        [HttpGet]
        public async Task<ActionResult<List<EquipamentListDto>>> GetAllEquipaments()
        {
            var equipaments = await _mediator.Send(new GetEquipamentsListRequest());
            return equipaments;
        }

        // GET api/<EquipamentController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipamentDto>> GetEquipament(int id)
        {
            var equipament = await _mediator.Send(new GetEquipamentDetailRequest { Id = id });
            return Ok(equipament);
        }

        // POST api/<EquipamentController>
        [HttpPost]
        public async Task<ActionResult> PostEquipament([FromBody] CreateEquipamentDto equipament)
        {
            var command = new CreateEquipamentCommand { EquipamentDto = equipament };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<EquipamentController>
        [HttpPut]
        public async Task<ActionResult> PutEquipament([FromBody] UpdateEquipamentDto equipament)
        {
            var command = new UpdateEquipamentCommand { EquipamentDto = equipament };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<EquipamentController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEquipament(int id)
        {
            var command = new DeleteEquipamentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
