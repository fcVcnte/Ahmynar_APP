using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.Features.Budget.Requests.Commands;
using Ahmynar_Application.Features.Budget.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BudgetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BudgetController>
        [HttpGet]
        public async Task<ActionResult<List<BudgetListDto>>> GetAllBudgets()
        {
            var budgets = await _mediator.Send(new GetBudgetsListRequest());
            return budgets;
        }

        // GET api/<BudgetController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetDto>> GetBudget(int id)
        {
            var budget = await _mediator.Send(new GetBudgetDetailRequest { Id = id });
            return Ok(budget);
        }

        // POST api/<BudgetController>
        [HttpPost]
        public async Task<ActionResult> PostBudget([FromBody] CreateBudgetDto budget)
        {
            var command = new CreateBudgetCommand { BudgetDto = budget };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<BudgetController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBudget(int id)
        {
            var command = new DeleteBudgetCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
