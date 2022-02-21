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
        public ActionResult<Category> GetAllBooks()
        {
            try
            {
                return Ok(_categoryService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public ActionResult<Category> GetById(int id)
        {
            try
            {
                return Ok(_categoryService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult<Category> Create([FromBody] Category newCategory)
        {
            try
            {
                if (newCategory == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(_categoryService.CreateAsync(newCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return Ok(_categoryService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult<Category> Update([FromBody] Category updatedCategory)
        {
            try
            {
                if (updatedCategory == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(_categoryService.UpdateAsync(updatedCategory));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
