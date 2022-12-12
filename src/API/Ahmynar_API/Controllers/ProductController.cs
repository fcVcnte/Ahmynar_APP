using Ahmynar_Application.DTOs.Product;
using Ahmynar_Application.Features.Product.Requests.Commands;
using Ahmynar_Application.Features.Product.Requests.Queries;
using Ahmynar_Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetProductsListRequest());
            return products;
        }

        // GET api/<ProductController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _mediator.Send(new GetProductDetailRequest { Id = id });
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> PostProduct([FromBody] CreateProductDto product)
        {
            var command = new CreateProductCommand { ProductDto = product };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ProductController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutProduct([FromBody] UpdateProductDto product)
        {
            var command = new UpdateProductCommand { ProductDto = product };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<ProductController>/CheckIn/{id}{quantityIn}
        [HttpPut("CheckIn/{id}|{quantityIn}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CheckInProduct(int id, int quantityIn)
        {
            var command = new CheckInProductCommand { Id = id, QuantityIn = quantityIn };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<ProductController>/CheckOut/{id}{quantityOut}
        [HttpPut("CheckOut/{id}|{quantityOut}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CheckOutProduct(int id, int quantityOut)
        {
            var command = new CheckOutProductCommand { Id = id, QuantityOut = quantityOut };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProductController>/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
