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

        public async Task<Book> CreateAsync(Book entity)
        {
            return await _unitOfWork._BookRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _unitOfWork._BookRepository.GetByIdAsync(id);

            book.IsDeleted = true;

            await _unitOfWork._BookRepository.UpdateAsync(book);

            return true;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _unitOfWork._BookRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Author>> GetBookAuthors(int id)
        {
            return await _unitOfWork._BookRepository.GetBookAuthors(id);
        }

        public async Task<IEnumerable<Category>> GetBookCategories(int id)
        {
            return await _unitOfWork._BookRepository.GetBookCategories(id);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(int id)
        {
            return await _unitOfWork._BookRepository.GetBooksByAuthor(id);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int id)
        {
            return await _unitOfWork._BookRepository.GetBooksByCategory(id);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _unitOfWork._BookRepository.GetByIdAsync(id);
        }

        public async Task<bool> ProcessBookDTO(BookDTO book)
        {
            try
            {
                using (var transactionScope = new TransactionScope())
                {
                    int newBookId = (await _unitOfWork._BookRepository.CreateAsync(
                        new Book
                        {
                            Count = book.Count,
                            Id = 0,
                            Name = book.Name,
                            Price = book.Price,
                            PublishingHouse = book.PublishingHouse,
                            IsDeleted = book.IsDeleted,
                        })).Id;

                    book.Categories.ForEach(async categoryId => 
                    {
                            await _unitOfWork._CategoryRepository.BindBookWithCategory(
                                    _bookId: newBookId,
                                    _categoryId: categoryId
                                    );
                    });

                    book.Authors.ForEach(async authorId =>
                    {
                        await _unitOfWork._AuthorRepository.BindBookWithAuthor(
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

        public async Task<Book> UpdateAsync(Book entity)
        {
            return await _unitOfWork._BookRepository.UpdateAsync(entity);
        }
    }
}
