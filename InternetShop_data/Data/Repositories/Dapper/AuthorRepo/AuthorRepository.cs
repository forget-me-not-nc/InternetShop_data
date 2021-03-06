using Dapper;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.Settings;
using MySql.Data.MySqlClient;
using System.Data;

namespace InternetShop_data.Data.Repositories.AuthorRepo
{
    public class AuthorRepository : GenericDapperRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext dbContext) : base(dbContext) { }

        public Task<Author> ADOGetByIdAsync(int id)
        {
            try
            {
                ConnectionOpen();

                MySqlConnection sqlConnection = new MySqlConnection();

                string query = "SELECT * FROM author WHERE Id = @Id";
                Author author = new Author();

                MySqlCommand command = new MySqlCommand(query, _dbConnection);
                command.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    author.Id = (int)reader[0];
                    author.FirstName = (string)reader[1];
                    author.LastName = (string)reader[2];
                    author.MiddleName = (string)reader[3];
                    author.Info = reader.IsDBNull(4) ? "" : (string)reader[4];
                }

                reader.Close();

                return Task.FromResult(author);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: ADOGetById.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public Task<bool> ADOUpdateAsync(Author entity)
        {
            try
            {
                ConnectionOpen();

                string query = "UPDATE author " +
                               "SET FirstName = @FirstName," +
                                    "LastName = @LastName," +
                                    "MiddleName = @MiddleName," +
                                    "Info = @Info " +
                                "WHERE Id = @Id";

                MySqlCommand command = new MySqlCommand(query, _dbConnection);

                return Task.FromResult(Convert.ToBoolean(command.ExecuteNonQuery()));
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: ADOUpdateAsync.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<bool> BindBookWithAuthor(int _bookId, int _authorId)
        {
            try
            {
                ConnectionOpen();

                return Convert.ToBoolean(await _dbConnection.ExecuteScalarAsync<int>(
                                sql: "INSERT INTO bookauthor (BookId, AuthorId) VALUES (@BookId,@AuthorId)",
                                param: new { BookId = _bookId, AuthorId = _authorId }
                            )
                        );
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to Bind book with author.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }
        public async Task<IEnumerable<Author>> GetBookAuthors(int Id)
        {
            try
            {
                ConnectionOpen();

                var res = _dbConnection.QueryAsync<Author>(
                        sql: "sp_getBookAuthors",
                        param: new { aId = Id },
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
