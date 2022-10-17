using Ahmynar_Application.DTOs.Sale;
using Ahmynar_Application.Features.Sale.Requests.Commands;
using Ahmynar_Application.Features.Sale.Requests.Queries;
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
        public async Task<ActionResult<List<SaleListDto>>> GetAllSales()
        {
            var sales = await _mediator.Send(new GetSalesListRequest());
            return sales;
        }

        // GET api/<SaleController>/SaleBudget/{id}
        [HttpGet("/[controller]/SaleBudget/{id}")]
        public async Task<ActionResult<SaleDto>> GetSaleBudget(int id)
        {
            var sale = await _mediator.Send(new GetSaleBudgetDetailRequest { Id = id });
            return Ok(sale);
        }

        // GET api/<SaleController>/SaleProducts/{id}
        [HttpGet("/[controller]/SaleProducts/{id}")]
        public async Task<ActionResult<SaleDto>> GetSaleProducts(int id)
        {
            var sale = await _mediator.Send(new GetSaleProductsDetailRequest { Id = id });
            return Ok(sale);
        }

        // POST api/<SaleController>/SaleBudget
        [HttpPost("/[controller]/SaleBudget")]
        public async Task<ActionResult> PostSaleBudget([FromBody] CreateSaleBudgetDto sale)
        {
            var command = new CreateSaleBudgetCommand { SaleBudgetDto = sale };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // POST api/<SaleController>/SaleProducts
        [HttpPost("/[controller]/SaleProducts")]
        public async Task<ActionResult> PostSaleProducts([FromBody] CreateSaleProductsDto sale)
        {
            var command = new CreateSaleProductsCommand { SaleProductsDto = sale };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
