using Microsoft.AspNetCore.Mvc;
using payFlow.Application.Categories.DTOs.Requests;
using payFlow.Application.Categories.Interfaces;
using payFlow.Application.Categories.Query;

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

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategory category)
        {
            var result = await _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(Create), result);
        }
    }
}
