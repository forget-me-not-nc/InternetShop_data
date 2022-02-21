using Dapper;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.Settings;
using System.Data;

namespace InternetShop_data.Data.Repositories.BookRepo
{
    public class BookRepository : GenericDapperRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
          
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(int Id)
        {
            try
            {
                ConnectionOpen();

                var res = _dbConnection.QueryAsync<Book>(
                        sql: "sp_getBookByAuthor",
                        param: new { authorId = Id },
                        commandType: CommandType.StoredProcedure
                    );

                return await res;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to Get books by categories.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int Id)
        {
            try
            {
                ConnectionOpen();

                var res = _dbConnection.QueryAsync<Book>(
                        sql: "sp_getBookByCategory",
                        param: new { categoryId = Id },
                        commandType: CommandType.StoredProcedure
                    );

                return await res;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to Get books by categories.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }
    }
}
