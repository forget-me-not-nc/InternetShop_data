using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.BookServices
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllAsync();
        Task<BookDTO> GetByIdAsync(int id);
        Task<BookDTO> CreateAsync(BookCreateRequest entity);
        Task<BookDTO> UpdateAsync(BookUpdateRequest entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<BookDTO>> GetBooksByCategory(int id);
        Task<IEnumerable<BookDTO>> GetBooksByAuthor(int id);
        Task<BookDTO> map(Book book);
    }
}
