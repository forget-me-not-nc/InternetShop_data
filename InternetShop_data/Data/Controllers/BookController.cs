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

        [HttpGet("getAll")]
        public ActionResult<Book> GetAllBooks()
        {
            try
            {
                return Ok(_bookService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public ActionResult<Book> GetById(int id)
        {
            try
            {
                return Ok(_bookService.GetByIdAsync(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public ActionResult<Book> Create([FromBody] Book newBook)
        {
            try
            {
                if (newBook == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");
                
                return Ok(_bookService.CreateAsync(newBook));
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
                return Ok(_bookService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult<Book> Update([FromBody] Book updatedBook)
        {
            try
            {
                if (updatedBook == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(_bookService.UpdateAsync(updatedBook));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("category/{id}")]
        public ActionResult<IEnumerable<Book>> getBookByCategory(int id)
        {
            try
            {
                return Ok(_bookService.GetBooksByCategory(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("author/{id}")]
        public ActionResult<IEnumerable<Book>> getBookByAuthor(int id)
        {
            try
            {
                return Ok(_bookService.GetBooksByAuthor(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
