using E_Commerce.Application.DTOs.Transaction;
using E_Commerce.Application.Features.Transaction.Requests.Commands;
using E_Commerce.Application.Features.Transaction.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public async Task<ActionResult<List<GetTransactionsListRequest>>> Get()
        {
            var transactions = await _mediator.Send(new GetTransactionsListRequest());
            return Ok(transactions);
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTransactionRequest>> Get(int id)
        {
            var transaction = await _mediator.Send(new GetTransactionRequest { Id = id });
            return Ok(transaction);
        }

        // POST api/<TransactionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTransactionDto transaction)
        {
            var command = new CreateTransactionCommand { CreateTransactionDto = transaction };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateTransactionDto transaction)
        {
            var command = new UpdateTransactionCommand { UpdateTransactionDto = transaction };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTransactionCommand { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
