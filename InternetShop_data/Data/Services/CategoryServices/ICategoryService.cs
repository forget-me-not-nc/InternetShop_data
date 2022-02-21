using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Services.CategoryServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllAsync();
        Category GetByIdAsync(int id);
        Category CreateAsync(Category entity);
        Category UpdateAsync(Category entity);
        bool DeleteAsync(int id);
    }
}
