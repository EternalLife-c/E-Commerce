using E_Commerce.Application.DTOs.Order;
using E_Commerce.Application.Features.Order.Requests.Commands;
using E_Commerce.Application.Features.Order.Requests.Queries;
using E_Commerce.Domain;
using EllipticCurve.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            var order = await _mediator.Send(new GetOrdersListRequest());
            return Ok(order);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var orders = await _mediator.Send(new GetOrderRequest { Id = id });
            return Ok(orders);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOrderDto order)
        {
            var command = new CreateOrderCommand { CreateOrderDto = order };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateOrderStatusDto order)
        {
            var command = new UpdateOrderStatusCommand { UpdateOrderStatusDto = order };
            var response = _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteOrderCommand { Id = id };
            var response = _mediator.Send(command);
            return NoContent();
        }
    }

    internal class CreateOrderCommand
    {
        public CreateOrderDto CreateOrderDto { get; set; }
    }
}
