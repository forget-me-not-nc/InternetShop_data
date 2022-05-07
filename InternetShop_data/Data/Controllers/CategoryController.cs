using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_data.Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> GetAllCategories()
        {
            try
            {
                return Ok(await _categoryService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            try
            {
                return Ok(await _categoryService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create([FromBody] Category newCategory)
        {
            try
            {
                if (newCategory == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _categoryService.CreateAsync(newCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                return Ok(await _categoryService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Update([FromBody] Category updatedCategory)
        {
            try
            {
                if (updatedCategory == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _categoryService.UpdateAsync(updatedCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("book/{id}")]
        public async Task<ActionResult<CategoryDTO>> GetBookCategories(int id)
        {
            try
            {
                return Ok(await _categoryService.GetBookCategories(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
