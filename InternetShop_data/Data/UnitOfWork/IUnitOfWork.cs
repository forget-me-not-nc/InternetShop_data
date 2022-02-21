using InternetShop_data.Data.Repositories.AuthorRepo;
using InternetShop_data.Data.Repositories.BookRepo;
using InternetShop_data.Data.Repositories.CategoryRepo;

namespace InternetShop_data.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBookRepository _BookRepository { get; }
        public ICategoryRepository _CategoryRepository { get; }
        public IAuthorRepository _AuthorRepository { get; }
    }
}
