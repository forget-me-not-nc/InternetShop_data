using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.Repositories.BookRepo;
using InternetShop_data.Data.Services.BookServices;
using InternetShop_data.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop_data.Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetAllBooks()
        {
            try
            {
                return Ok(await _bookService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            try
            {
                return Ok(await _bookService.GetByIdAsync(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create([FromBody] Book newBook)
        {
            try
            {
                if (newBook == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");
                
                return Ok(await _bookService.CreateAsync(newBook));
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
                return Ok(await _bookService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Update([FromBody] Book updatedBook)
        {
            try
            {
                if (updatedBook == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _bookService.UpdateAsync(updatedBook));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> getBookByCategory(int id)
        {
            try
            {
                return Ok(await _bookService.GetBooksByCategory(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("author/{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> getBookByAuthor(int id)
        {
            try
            {
                return Ok(await _bookService.GetBooksByAuthor(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("detailedCreate")]
        public async Task<ActionResult<bool>> DetailedCreate([FromBody] BookDTO newBook)
        {
            try
            {
                if (newBook == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _bookService.ProcessBookDTO(newBook));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/categories")]
        public async Task<ActionResult<Book>> GetBookCategories(int id)
        {
            try
            {
                return Ok(await _bookService.GetBookCategories(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}/authors")]
        public async Task<ActionResult<Book>> GetBookAuthors(int id)
        {
            try
            {
                return Ok(await _bookService.GetBookAuthors(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
