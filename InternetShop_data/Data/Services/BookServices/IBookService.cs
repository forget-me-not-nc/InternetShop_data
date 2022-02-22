using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.BookServices
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllAsync();
        Book GetByIdAsync(int id);
        Book CreateAsync(Book entity);
        Book UpdateAsync(Book entity);
        bool DeleteAsync(int id);
        IEnumerable<Book> GetBooksByCategory(int id);
        IEnumerable<Book> GetBooksByAuthor(int id);
        bool ProcessBookDTO(BookDTO book);
    }
}
