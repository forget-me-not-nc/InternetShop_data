using InternetShop_data.Data.DTO;
using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<CategoryDTO> CreateAsync(Category entity);
        Task<CategoryDTO> UpdateAsync(Category entity);
        Task<bool> DeleteAsync(int id);
        CategoryDTO map(Category category);
        Task<IEnumerable<CategoryDTO>> GetBookCategories(int id);
    }
}
