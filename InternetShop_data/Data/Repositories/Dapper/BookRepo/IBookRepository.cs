using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Repositories.BookRepo
{
    public interface IBookRepository : IGenericDapperRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByCategory(int Id);
        Task<IEnumerable<Book>> GetBooksByAuthor(int Id);
    }
}
