using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.BookServices
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book entity);
        Task<Book> UpdateAsync(Book entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Book>> GetBooksByCategory(int id);
        Task<IEnumerable<Book>> GetBooksByAuthor(int id);
        Task<bool> ProcessBookDTO(BookDTO book);
        Task<IEnumerable<Author>> GetBookAuthors(int id);
        Task<IEnumerable<Category>> GetBookCategories(int id);
    }
}
