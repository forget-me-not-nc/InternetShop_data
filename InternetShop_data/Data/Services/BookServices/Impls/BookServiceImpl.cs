using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.UnitOfWork;
using System.Transactions;

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

        public bool ProcessBookDTO(BookDTO book)
        {
            try
            {
                using (var transactionScope = new TransactionScope())
                {
                    int newBookId = _unitOfWork._BookRepository.CreateAsync(
                        new Book
                        {
                            Count = book.Count,
                            Id = 0,
                            Name = book.Name,
                            Price = book.Price,
                            PublishingHouse = book.PublishingHouse
                        }).Result.Id;

                    book.Categories.ForEach(categoryId => 
                    {
                            _unitOfWork._CategoryRepository.BindBookWithCategory(
                                    _bookId: newBookId,
                                    _categoryId: categoryId
                                    );
                    });

                    book.Authors.ForEach(authorId =>
                    {
                        _unitOfWork._AuthorRepository.BindBookWithAuthor(
                                _bookId: newBookId,
                                _authorId: authorId
                                );
                    });


                    transactionScope.Complete();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Book UpdateAsync(Book entity)
        {
            return _unitOfWork._BookRepository.UpdateAsync(entity).Result;
        }
    }
}
