using InternetShop_data.Data.DTO;
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

        public async Task<AuthorDTO> CreateAsync(Author entity)
        {
            return map(await _unitOfWork._AuthorRepository.CreateAsync(entity));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork._AuthorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAsync()
        {
            return (await _unitOfWork._AuthorRepository.GetAllAsync())
                .Select(e => map(e)).ToList();
        }

        public async Task<AuthorDTO> GetByIdAsync(int id)
        {
            return map(await _unitOfWork._AuthorRepository.GetByIdAsync(id));
        }

        public async Task<AuthorDTO> UpdateAsync(Author entity)
        {
            return map(await _unitOfWork._AuthorRepository.UpdateAsync(entity));
        }

        public AuthorDTO map(Author author)
        {
            return new AuthorDTO
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleName = author.MiddleName,
                Id = author.Id,
            };
        }

        public async Task<IEnumerable<AuthorDTO>> GetBookAuthors(int bookId)
        {
            return (await _unitOfWork._AuthorRepository.GetBookAuthors(bookId))
                .Select(e => map(e)).ToList();
        }
    }
}
