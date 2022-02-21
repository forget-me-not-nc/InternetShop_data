using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.AuthorServices
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAsync();
        Author GetByIdAsync(int id);
        Author CreateAsync(Author entity);
        Author UpdateAsync(Author entity);
        bool DeleteAsync(int id);
    }
}
