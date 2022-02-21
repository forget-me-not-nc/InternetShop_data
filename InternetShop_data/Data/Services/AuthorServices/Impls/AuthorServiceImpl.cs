using InternetShop_data.Data.Entities;
using InternetShop_data.Data.UnitOfWork;

namespace InternetShop_data.Data.Services.AuthorServices.Impls
{
    public class AuthorServiceImpl : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Author CreateAsync(Author entity)
        {
            return _unitOfWork._AuthorRepository.CreateAsync(entity).Result;
        }

        public bool DeleteAsync(int id)
        {
            return _unitOfWork._AuthorRepository.DeleteAsync(id).Result;
        }

        public IEnumerable<Author> GetAllAsync()
        {
            return _unitOfWork._AuthorRepository.GetAllAsync().Result;
        }

        public Author GetByIdAsync(int id)
        {
            return _unitOfWork._AuthorRepository.GetByIdAsync(id).Result;
        }

        public Author UpdateAsync(Author entity)
        {
            return _unitOfWork._AuthorRepository.UpdateAsync(entity).Result;
        }
    }
}
