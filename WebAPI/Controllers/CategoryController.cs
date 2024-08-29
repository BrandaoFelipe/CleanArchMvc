using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var category = await _categoryService.GetAllCategories();

            if (category == null)
            {
                return NotFound("Category is empty");
            }

            return Ok(category);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<CategoryDTO>> GetById(int? id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Could not found ID");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create([FromBody] CategoryDTO category)
        {
            if (category is null)
            {
                return BadRequest("There is an error with your request");
            }

            await _categoryService.Add(category);

            return new CreatedAtRouteResult("GetProduct", new {id = category.Id}, category);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Update(CategoryDTO category)
        {
            if (category is null)
            {
                return BadRequest("There is an error with your request");
            }

            await _categoryService.Update(category);

            return Ok(category);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int? id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Could not found ID");
            }

            await _categoryService.Delete(category.Id);

            return Ok(category);

        }
    }
}
