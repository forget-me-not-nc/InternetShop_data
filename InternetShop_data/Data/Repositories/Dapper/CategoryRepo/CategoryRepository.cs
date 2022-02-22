using Dapper;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.Settings;

namespace InternetShop_data.Data.Repositories.CategoryRepo
{
    public class CategoryRepository : GenericDapperRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<bool> BindBookWithCategory(int _bookId, int _categoryId)
        {
            try
            {
                ConnectionOpen();

                return Convert.ToBoolean(await _dbConnection.ExecuteScalarAsync<int>(
                            sql: "INSERT INTO bookcategory (BookId, CategoryId) VALUES (@BookId,@CategoryId)",
                            param: new { BookId = _bookId, CategoryId = _categoryId }
                        )
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to Bind book with category.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }
    }
}
