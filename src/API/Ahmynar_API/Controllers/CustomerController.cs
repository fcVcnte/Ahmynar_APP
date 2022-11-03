using Ahmynar_Application.DTOs.Customer;
using Ahmynar_Application.Features.Customer.Requests.Commands;
using Ahmynar_Application.Features.Customer.Requests.Queries;
using Ahmynar_Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetCustomersListRequest());
            return customers;
        }

        // GET api/<CustomerController>/LegalEntity/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerDetailRequest { Id = id });
            return Ok(customer);
        }

        // POST api/<CustomerController>/LegalEntity
        [HttpPost("/[controller]/LegalEntity")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> PostLegalEntityCustomer([FromBody] CreateLegalEntityCustomerDto customer)
        {
            var command = new CreateLegalEntityCustomerCommand { LegalEntityDto = customer };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // POST api/<CustomerController>/NaturalPerson
        [HttpPost("/[controller]/NaturalPerson")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> PostNaturalPersonCustomer([FromBody] CreateNaturalPersonCustomerDto customer)
        {
            var command = new CreateNaturalPersonCustomerCommand { NaturalPersonDto = customer };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CustomerController>/LegalEntity
        [HttpPut("/[controller]/LegalEntity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutLegalEntityCustomer([FromBody] UpdateLegalEntityCustomerDto customer)
        {
            var command = new UpdateLegalEntityCustomerCommand { LegalEntityDto = customer };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<CustomerController>/NaturalPerson
        [HttpPut("/[controller]/NaturalPerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutNaturalPersonCustomer([FromBody] UpdateNaturalPersonCustomerDto customer)
        {
            var command = new UpdateNaturalPersonCustomerCommand { NaturalPersonDto = customer };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CustomerController>/{id}
        [HttpDelete("/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
