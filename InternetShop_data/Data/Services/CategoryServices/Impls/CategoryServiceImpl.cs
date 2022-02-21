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
        public Category CreateAsync(Category entity)
        {
            return _unitOfWork._CategoryRepository.CreateAsync(entity).Result;   
        }

        public bool DeleteAsync(int id)
        {
            return _unitOfWork._CategoryRepository.DeleteAsync(id).Result;
        }

        public IEnumerable<Category> GetAllAsync()
        {
            return _unitOfWork._CategoryRepository.GetAllAsync().Result;
        }

        public Category GetByIdAsync(int id)
        {
            return _unitOfWork._CategoryRepository.GetByIdAsync(id).Result;
        }

        public Category UpdateAsync(Category entity)
        {
            return _unitOfWork._CategoryRepository.UpdateAsync(entity).Result;
        }
    }
}
