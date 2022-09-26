﻿using Ahmynar_Application.DTOs.ServiceOrder;
using Ahmynar_Application.Features.ServiceOrder.Requests.Commands;
using Ahmynar_Application.Features.ServiceOrder.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahmynar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ServiceOrderController>
        [HttpGet]
        public async Task<ActionResult<List<ServiceOrderListDto>>> GetAllServiceOrders()
        {
            var serviceOrders = await _mediator.Send(new GetServiceOrdersListRequest());
            return serviceOrders;
        }

        // GET api/<ServiceOrderController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceOrderDto>> GetServiceOrder(int id)
        {
            var serviceOrder = await _mediator.Send(new GetServiceOrderDetailRequest { Id = id });
            return Ok(serviceOrder);
        }

        // POST api/<ServiceOrderController>
        [HttpPost]
        public async Task<ActionResult> PostServiceOrder([FromBody] CreateServiceOrderDto serviceOrder)
        {
            var command = new CreateServiceOrderCommand { ServiceOrderDto = serviceOrder };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ServiceOrderController>/
        [HttpPut]
        public async Task<ActionResult> PutServiceOrder([FromBody] UpdateServiceOrderDto serviceOrder)
        {
            var command = new UpdateServiceOrderCommand { ServiceOrderDto = serviceOrder };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ServiceOrderController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServiceOrder(int id)
        {
            var command = new DeleteServiceOrderCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}