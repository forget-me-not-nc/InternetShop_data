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
        public async Task<Category> CreateAsync(Category entity)
        {
            return await _unitOfWork._CategoryRepository.CreateAsync(entity);   
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork._CategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork._CategoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _unitOfWork._CategoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            return await _unitOfWork._CategoryRepository.UpdateAsync(entity);
        }
    }
}
