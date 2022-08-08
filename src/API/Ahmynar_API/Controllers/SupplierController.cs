using Ahmynar_Application.DTOs.Supplier;
using Ahmynar_Application.Features.Supplier.Requests.Commands;
using Ahmynar_Application.Features.Supplier.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<ActionResult<List<SupplierDto>>> GetAllSuppliers()
        {
            var suppliers = await _mediator.Send(new GetSuppliersListRequest());
            return suppliers;
        }

        // GET api/<SupplierController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(int id)
        {
            var supplier = await _mediator.Send(new GetSupplierDetailRequest { Id = id });
            return Ok(supplier);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<ActionResult> PostSupplier([FromBody] CreateSupplierDto supplier)
        {
            var command = new CreateSupplierCommand { SupplierDto = supplier };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<SupplierController>/
        [HttpPut]
        public async Task<ActionResult> PutSupplier([FromBody] UpdateSupplierDto supplier)
        {
            var command = new UpdateSupplierCommand { SupplierDto = supplier };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<SupplierController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            var command = new DeleteSupplierCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
