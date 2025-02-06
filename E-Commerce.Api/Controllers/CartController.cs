using E_Commerce.Application.DTOs.Cart;
using E_Commerce.Application.Features.Cart.Requests.Commands;
using E_Commerce.Application.Features.Cart.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CartController>
        [HttpGet]
        public async Task<ActionResult<List<Cart>>> Get()
        {
            var carts = await _mediator.Send(new GetCartsListRequest());
            return Ok(carts);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> Get(int id)
        {
            var cart = await _mediator.Send(new GetCartRequest { Id = id});
            return Ok(cart);
        }

        // POST api/<CartController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCartDto cart)
        {
            var command = new CreateCartCommand { CreateCartDto = cart };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCartDto cart)
        {
            var command = new UpdateCartCommand { UpdateCartDto = cart };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCartCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
