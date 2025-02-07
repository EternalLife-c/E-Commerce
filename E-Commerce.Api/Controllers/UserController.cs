using E_Commerce.Application.DTOs.User;
using E_Commerce.Application.Features.User.Requests.Commands;
using E_Commerce.Application.Features.User.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _mediator.Send(new GetUsersListRequest());
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserRequest { Id = id });
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDto user)
        {
            var command = new CreateUserCommand { CreateUserDto = user };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUserDto user)
        {
            var command = new UpdateUserCommand { UpdateUserDto = user };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
