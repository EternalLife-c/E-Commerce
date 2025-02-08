using E_Commerce.Application.DTOs.Comment;
using E_Commerce.Application.Features.Comment.Requests.Commands;
using E_Commerce.Application.Features.Comment.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> Get()
        {
            var comments = await _mediator.Send(new GetCommentsListRequest());
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(Guid id)
        {
            var comment = await _mediator.Send(new GetCommentRequest { Id = id});
            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCommentDto comment)
        {
            var command = new CreateCommentCommand { CreateCommentDto = comment };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateCommentDto comment)
        {
            var command = new UpdateCommentCommand { UpdateCommentDto = comment };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCommentCommand { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}