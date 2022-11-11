using Ahmynar_Application.DTOs.Sale;
using Ahmynar_Application.Features.Sale.Requests.Commands;
using Ahmynar_Application.Features.Sale.Requests.Queries;
using Ahmynar_Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SaleController>
        [HttpGet]
        public async Task<ActionResult<List<SaleDto>>> GetAllSales()
        {
            var sales = await _mediator.Send(new GetSalesListRequest());
            return sales;
        }

        // GET api/<SaleController>/Sale/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDto>> GetSale(int id)
        {
            var sale = await _mediator.Send(new GetSaleDetailRequest { Id = id });
            return Ok(sale);
        }

        // POST api/<SaleController>/SaleBudget
        [HttpPost("SaleBudget")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> PostSaleBudget([FromBody] CreateSaleBudgetDto sale)
        {
            var command = new CreateSaleBudgetCommand { SaleBudgetDto = sale };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // POST api/<SaleController>/SaleProducts
        [HttpPost("SaleProducts")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> PostSaleProducts([FromBody] CreateSaleProductsDto sale)
        {
            var command = new CreateSaleProductsCommand { SaleProductsDto = sale };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
