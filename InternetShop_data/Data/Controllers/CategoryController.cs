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

        [HttpGet("getAll")]
        public async Task<ActionResult<Category>> GetAllCategories()
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

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
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

        [HttpPost("create")]
        public async Task<ActionResult<Category>> Create([FromBody] Category newCategory)
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

        [HttpDelete("delete/{id}")]
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

        [HttpPut("update")]
        public async Task<ActionResult<Category>> Update([FromBody] Category updatedCategory)
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
    }
}
