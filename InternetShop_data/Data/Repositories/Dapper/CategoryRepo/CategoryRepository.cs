using InternetShop_data.Data.Entities;
using InternetShop_data.Data.Settings;

namespace InternetShop_data.Data.Repositories.CategoryRepo
{
    public class CategoryRepository : GenericDapperRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
