using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> CreateAsync(Author entity);
        Task<Author> UpdateAsync(Author entity);
        Task<bool> DeleteAsync(int id);
    }
}
