using E_Commerce.Application.DTOs.Category;
using E_Commerce.Application.Features.Category.Requests.Commands;
using E_Commerce.Application.Features.Category.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var categories = await _mediator.Send(new GetCategoriesListRequest());
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryRequest { Id = id });
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCategoryDto category)
        {
            var command = new CreateCategoryCommand { CreateCategoryDto = category };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateCategoryDto category)
        {
            var command = new UpdateCategoryCommand { UpdateCategoryDto = category };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
