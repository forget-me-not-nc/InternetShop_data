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

        public async Task<BookDTO> UpdateAsync(BookUpdateRequest entity)
        {
            var res = await _unitOfWork._BookRepository.UpdateAsync(
                    new Book
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Price = entity.Price,
                        PublishingHouse = entity.PublishingHouse,
                        IsDeleted = entity.IsDeleted,
                        Count = entity.Count,
                    }
                );

            return await map(res);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _unitOfWork._BookRepository.GetByIdAsync(id);

            book.IsDeleted = true;

            await _unitOfWork._BookRepository.UpdateAsync(book);

            return true;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            return (await _unitOfWork._BookRepository.GetAllAsync())
                .Select(async a => await map(a))
                .Select(e => e.Result);
        }

        public async Task<IEnumerable<BookDTO>> GetBooksByAuthor(int id)
        {
            return (await _unitOfWork._BookRepository.GetBooksByAuthor(id))
                .Select(async a => await map(a))
                .Select(e => e.Result);
        }

        public async Task<IEnumerable<BookDTO>> GetBooksByCategory(int id)
        {
            return (await _unitOfWork._BookRepository.GetBooksByCategory(id))
                .Select(async a => await map(a))
                .Select(e => e.Result);       
        }

        public async Task<BookDTO> GetByIdAsync(int id)
        {
            return await map(await _unitOfWork._BookRepository.GetByIdAsync(id));
        }

        public async Task<BookDTO> map(Book book)
        {
            List<AuthorDTO> authors = (await _unitOfWork._AuthorRepository.GetBookAuthors(book.Id))
                .Select(a => map(a)).ToList();

            List<CategoryDTO> categories = (await _unitOfWork._CategoryRepository.GetBookCategories(book.Id))
                .Select(a => map(a)).ToList();

            return new BookDTO
            { 
                Id = book.Id,
                Name = book.Name,
                Price = book.Price,
                PublishingHouse = book.PublishingHouse,
                Authors = authors,
                Categories = categories
            };
        }

        private AuthorDTO map(Author author)
        {
            return new AuthorDTO
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleName = author.MiddleName,
                Id = author.Id,
            };
        }

        private CategoryDTO map(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<BookDTO> CreateAsync(BookCreateRequest entity)
        {
            try
            {
                int bookId = 0;

                using (var transactionScope = new TransactionScope())
                {
                    int newBookId = (await _unitOfWork._BookRepository.CreateAsync(
                        new Book
                        {
                            Count = entity.Count,
                            Id = 0,
                            Name = entity.Name,
                            Price = entity.Price,
                            PublishingHouse = entity.PublishingHouse,
                            IsDeleted = entity.IsDeleted,
                        })).Id;

                    bookId = newBookId;

                    entity.Categories.ForEach(async categoryId =>
                    {
                        await _unitOfWork._CategoryRepository.BindBookWithCategory(
                                _bookId: newBookId,
                                _categoryId: categoryId
                                );
                    });

                    entity.Authors.ForEach(async authorId =>
                    {
                        await _unitOfWork._AuthorRepository.BindBookWithAuthor(
                                _bookId: newBookId,
                                _authorId: authorId
                                );
                    });

                    transactionScope.Complete();
                }

                return await map(await _unitOfWork._BookRepository.GetByIdAsync(bookId));
            }
            catch
            {
                return await Task.FromResult(new BookDTO()); ;
            }
        }
    }
}
