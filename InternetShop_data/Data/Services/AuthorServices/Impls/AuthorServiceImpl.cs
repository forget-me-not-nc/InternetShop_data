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

        public async Task<Author> CreateAsync(Author entity)
        {
            return await _unitOfWork._AuthorRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork._AuthorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _unitOfWork._AuthorRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _unitOfWork._AuthorRepository.GetByIdAsync(id);
        }

        public async Task<Author> UpdateAsync(Author entity)
        {
            return await _unitOfWork._AuthorRepository.UpdateAsync(entity);
        }
    }
}
