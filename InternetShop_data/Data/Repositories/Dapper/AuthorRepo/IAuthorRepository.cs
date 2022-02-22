using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Repositories.AuthorRepo
{
    public interface IAuthorRepository : IGenericDapperRepository<Author>
    {
        Task<Author> ADOGetByIdAsync(int id);
        Task<bool> ADOUpdateAsync(Author entity);
        Task<bool> BindBookWithAuthor(int _bookId, int _authorId);
    }
}
