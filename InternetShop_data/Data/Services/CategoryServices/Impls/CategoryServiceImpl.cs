using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.UnitOfWork;

namespace InternetShop_data.Data.Services.CategoryServices.Impls
{
    public class CategoryServiceImpl : ICategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CategoryDTO> CreateAsync(Category entity)
        {
            return map(await _unitOfWork._CategoryRepository.CreateAsync(entity));   
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork._CategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            return (await _unitOfWork._CategoryRepository.GetAllAsync())
                .Select(e => map(e)).ToList();
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            return map(await _unitOfWork._CategoryRepository.GetByIdAsync(id));
        }

        public async Task<CategoryDTO> UpdateAsync(Category entity)
        {
            return map(await _unitOfWork._CategoryRepository.UpdateAsync(entity));
        }

        public CategoryDTO map(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<IEnumerable<CategoryDTO>> GetBookCategories(int id)
        {
            return (await _unitOfWork._CategoryRepository.GetBookCategories(id))
                .Select(e => map(e)).ToList();
             
        }
    }
}
