using InternetShop_data.Data.Entities;

namespace InternetShop_data.Data.Repositories.CategoryRepo
{
    public interface ICategoryRepository : IGenericDapperRepository<Category>
    {
        Task<bool> BindBookWithCategory(int _bookId, int _categoryId);
        Task<IEnumerable<Category>> GetBookCategories(int Id);
    }
}
