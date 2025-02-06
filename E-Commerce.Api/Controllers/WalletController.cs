using E_Commerce.Application.DTOs.Wallet;
using E_Commerce.Application.Features.Wallet.Requests.Commands;
using E_Commerce.Application.Features.Wallet.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<WalletController>
        [HttpGet]
        public async Task<ActionResult<List<Wallet>>> Get()
        {
            var wallets = await _mediator.Send(new GetWalletsListRequest());
            return Ok(wallets);
        }

        // GET api/<WalletController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> Get(int id)
        {
            var wallet = await _mediator.Send(new GetWalletRequest { Id = id });
            return Ok(wallet);
        }

        // POST api/<WalletController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateWalletDto wallet)
        {
            var command = new CreateWalletCommand { CreateWalletDto = wallet };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        // PUT api/<WalletController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateWalletDto wallet)
        {
            var command = new UpdateWalletCommand { UpdateWalletDto = wallet };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<WalletController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteWalletCommand { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
