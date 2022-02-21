using InternetShop_data.Data.Repositories.AuthorRepo;
using InternetShop_data.Data.Repositories.BookRepo;
using InternetShop_data.Data.Repositories.CategoryRepo;

namespace InternetShop_data.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IBookRepository _BookRepository;
        public readonly ICategoryRepository _CategoryRepository;
        public readonly IAuthorRepository _AuthorRepository;

        public UnitOfWork(
            IBookRepository BookRepository,
            ICategoryRepository CategoryRepository,
            IAuthorRepository AuthorRepository)
        {
            _BookRepository = BookRepository;
            _CategoryRepository = CategoryRepository;
            _AuthorRepository = AuthorRepository;
        }

        IBookRepository IUnitOfWork._BookRepository => _BookRepository;

        ICategoryRepository IUnitOfWork._CategoryRepository => _CategoryRepository;

        IAuthorRepository IUnitOfWork._AuthorRepository => _AuthorRepository;
    }
}
