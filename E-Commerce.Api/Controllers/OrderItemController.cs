using E_Commerce.Application.DTOs.OrderItem;
using E_Commerce.Application.Features.OrderItem.Requests.Commands;
using E_Commerce.Application.Features.OrderItem.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderItemController>
        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> Get()
        {
            var orderItems = await _mediator.Send(new GetOrderItemsListRequest());
            return Ok(orderItems);
        }

        // GET api/<OrderItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> Get(Guid id)
        {
            var orderItem = await _mediator.Send(new GetOrderItemRequest { Id = id });
            return Ok(orderItem);
        }

        // POST api/<OrderItemController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateOrderItemDto orderItem)
        {
            var command = new CreateOrderItemCommand { CreateOrderItemDto = orderItem };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<OrderItemController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateOrderItemDto orderItem)
        {
            var command = new UpdateOrderItemCommand { UpdateOrderItemDto = orderItem };
            var response = _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<OrderItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteOrderItemCommand {Id = id};
            var response = _mediator.Send(command);
            return NoContent();
        }
    }
}
