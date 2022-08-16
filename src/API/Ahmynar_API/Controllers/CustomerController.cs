using Ahmynar_Application.DTOs.Customer;
using Ahmynar_Application.Features.Customer.Requests.Commands;
using Ahmynar_Application.Features.Customer.Requests.Queries;
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
        [HttpGet("/[controller]s")]
        public async Task<ActionResult<List<CustomerListDto>>> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetCustomersListRequest());
            return customers;
        }

        // GET api/<CustomerController>/LegalEntity/{id}
        [HttpGet("/[controller]/LegalEntity/{id}")]
        public async Task<ActionResult<LegalEntityCustomerDto>> GetLegalEntityCustomer(int id)
        {
            var customer = await _mediator.Send(new GetLegalEntityCustomerDetailRequest { Id = id });
            return Ok(customer);
        }

        // GET api/<CustomerController>/NaturalPerson/{id}
        [HttpGet("/[controller]/NaturalPerson/{id}")]
        public async Task<ActionResult<NaturalPersonCustomerDto>> GetNaturalPersonCustomer(int id)
        {
            var customer = await _mediator.Send(new GetNaturalPersonCustomerDetailRequest { Id = id });
            return Ok(customer);
        }

        // POST api/<CustomerController>/LegalEntity
        [HttpPost("/[controller]/LegalEntity")]
        public async Task<ActionResult> PostLegalEntityCustomer([FromBody] CreateLegalEntityCustomerDto customer)
        {
            var command = new CreateLegalEntityCustomerCommand { LegalEntityDto = customer };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // POST api/<CustomerController>/NaturalPerson
        [HttpPost("/[controller]/NaturalPerson")]
        public async Task<ActionResult> PostNaturalPersonCustomer([FromBody] CreateNaturalPersonCustomerDto customer)
        {
            var command = new CreateNaturalPersonCustomerCommand { NaturalPersonDto = customer };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CustomerController>/LegalEntity
        [HttpPut("/[controller]/LegalEntity")]
        public async Task<ActionResult> PutLegalEntityCustomer([FromBody] UpdateLegalEntityCustomerDto customer)
        {
            var command = new UpdateLegalEntityCustomerCommand { LegalEntityDto = customer };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<CustomerController>/NaturalPerson
        [HttpPut("/[controller]/NaturalPerson")]
        public async Task<ActionResult> PutNaturalPersonCustomer([FromBody] UpdateNaturalPersonCustomerDto customer)
        {
            var command = new UpdateNaturalPersonCustomerCommand { NaturalPersonDto = customer };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CustomerController>/{id}
        [HttpDelete("/[controller]/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
