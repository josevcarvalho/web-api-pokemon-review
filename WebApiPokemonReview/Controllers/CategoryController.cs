using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Application.Features;

namespace PokemonReview.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var query = new GetAllCategoryQuery();
            var response = await mediator.Send(query, cancellationToken);
            return Ok(response);
        } 

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory([FromRoute] int categoryId, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery(categoryId);
            var response = await mediator.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpGet("pokemon/{categoryId}")]
        public async Task<IActionResult> GetPokemonByCategory([FromRoute] int categoryId, CancellationToken cancellationToken)
        {
            var query = new GetPokemonByCategoryQuery(categoryId);
            var response = await mediator.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryCreate, CancellationToken cancellationToken)
        {
        }

        [HttpPut("{categoryId}")]
        public Task<IActionResult> UpdateCategory([FromRoute] int categoryId, CancellationToken cancellationToken) 
        {
        }

        [HttpDelete("{categoryId}")]
        public Task<IActionResult> DeleteCategory([FromRoute] int categoryId, CancellationToken cancellationToken)
        {
        }
    }
}
