using InternetShop_data.Data.Entities;
using InternetShop_data.Data.UnitOfWork;

namespace InternetShop_data.Data.Services.BookServices.Impls
{
    public class BookServiceImpl : IBookService
    {
        private IUnitOfWork _unitOfWork;

        public BookServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Book CreateAsync(Book entity)
        {
            return _unitOfWork._BookRepository.CreateAsync(entity).Result;
        }

        public bool DeleteAsync(int id)
        {
            return _unitOfWork._BookRepository.DeleteAsync(id).Result;
        }

        public IEnumerable<Book> GetAllAsync()
        {
            return _unitOfWork._BookRepository.GetAllAsync().Result;
        }

        public IEnumerable<Book> GetBooksByAuthor(int id)
        {
            return _unitOfWork._BookRepository.GetBooksByAuthor(id).Result;
        }

        public IEnumerable<Book> GetBooksByCategory(int id)
        {
            return _unitOfWork._BookRepository.GetBooksByCategory(id).Result;
        }

        public Book GetByIdAsync(int id)
        {
            return _unitOfWork._BookRepository.GetByIdAsync(id).Result;
        }

        public Book UpdateAsync(Book entity)
        {
            return _unitOfWork._BookRepository.UpdateAsync(entity).Result;
        }
    }
}
