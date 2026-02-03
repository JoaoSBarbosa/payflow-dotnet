using Microsoft.AspNetCore.Mvc;
using payFlow.Api.Contracts.Response;
using payFlow.Application.Features.Categories.Interfaces;
using payFlow.Application.Features.Categories.Query;
using payFlow.Application.Features.Categories.Requests;
using payFlow.Application.Features.Categories.Response;

namespace payFlow.Api.Controllers
{

    [ApiController]
    [Route("V1/categories")]
    public class CategoryController(ICategoryService category) : ControllerBase
    {
        private readonly ICategoryService _categoryService = category;

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] CategoryFilter filter)
        {
            var result = await _categoryService.GetAllAsync(filter);
            return Ok(result);

        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult> GetById([FromRoute] long id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategory category)
        {
            var result = await _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
