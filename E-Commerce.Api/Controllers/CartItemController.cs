using E_Commerce.Application.DTOs.CartItem;
using E_Commerce.Application.Features.CartItem.Requests.Commands;
using E_Commerce.Application.Features.CartItem.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CartItemController>
        [HttpGet]
        public async Task<ActionResult<List<CartItem>>> Get()
        {
            var cartItems = await _mediator.Send(new GetCartItemsListRequest());
            return Ok(cartItems);
        }

        // GET api/<CartItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> Get(int id)
        {
            var cartItem = await _mediator.Send(new GetCartItemRequest { Id = id });
            return Ok(cartItem);
        }

        // POST api/<CartItemController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCartItemDto cartItem)
        {
            var command = new CreateCartItemCommand { CreateCartItemDto = cartItem };
            var respone = await _mediator.Send(command);
            return Ok(respone);
        }

        // PUT api/<CartItemController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCartItemDto cartItem)
        {
            var command = new UpdateCartItemCommand { UpdateCartItemDto = cartItem };
            var respone = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CartItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCartItemCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
