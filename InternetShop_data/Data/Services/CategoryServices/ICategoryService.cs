using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category entity);
        Task<Category> UpdateAsync(Category entity);
        Task<bool> DeleteAsync(int id);
    }
}
