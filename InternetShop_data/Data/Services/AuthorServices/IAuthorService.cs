using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAllAsync();
        Task<AuthorDTO> GetByIdAsync(int id);
        Task<AuthorDTO> CreateAsync(Author entity);
        Task<AuthorDTO> UpdateAsync(Author entity);
        Task<bool> DeleteAsync(int id);
        AuthorDTO map(Author author);
        Task<IEnumerable<AuthorDTO>> GetBookAuthors(int bookId);
    }
}
