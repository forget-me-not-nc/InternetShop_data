using Dapper;
using DapperExtensions;
using InternetShop_data.Data.Entities;
using InternetShop_data.Data.Settings;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using System.Text;

namespace InternetShop_data.Data.Repositories
{
    public class GenericDapperRepository<TEntity> : IGenericDapperRepository<TEntity> where TEntity : class
    {
        //fields

        protected readonly DbContext _dbContext;
        protected readonly MySqlConnection _dbConnection;

        //additional methods
        private string _tableName = typeof(TEntity).Name;
        private List<PropertyInfo> entityProperties () => typeof(TEntity).GetProperties().Where(prop => prop.Name != "Id").ToList();

        private string GetInsertQuery()
        {
            StringBuilder sql = new StringBuilder($"INSERT INTO {_tableName} (");

            entityProperties().ForEach(prop =>
            {
                sql.Append(prop.Name + ',');
            });

            sql[^1] = ')';
            sql.Append(" VALUES (");

            entityProperties().ForEach(prop =>
            {
                sql.Append("@" + prop.Name + ",");
            });

            sql[sql.Length - 1] = ')';
            sql.Append("; SELECT LAST_INSERT_ID()");

            return sql.ToString();
        }
        private string GetUpdateQuery()
        {
            StringBuilder sql = new StringBuilder($"UPDATE {_tableName} SET ");

            entityProperties().ForEach(prop =>
            {
                sql.Append(prop.Name + " = " + "@" + prop.Name + ',');
            });

            sql.Remove(sql.Length - 1, 1);
            sql.Append(" WHERE Id = @Id");
            sql.Append("; SELECT @Id");

            return sql.ToString();
        }

        //constructor
        public GenericDapperRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbConnection = new MySqlConnection(_dbContext.ConnectionString);
        }

        //Async CRUD 
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                ConnectionOpen();

                return await GetByIdAsync(
                    id: _dbConnection.ExecuteScalarAsync<int>(
                        sql: GetInsertQuery(),
                        param: entity).Result
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to Create.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                ConnectionOpen();

                return Convert.ToBoolean(await _dbConnection.ExecuteAsync(
                    sql: $"DELETE FROM {_tableName} WHERE Id = @Id",
                    param: new { Id = id }));
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to Delete.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                ConnectionOpen();

                return await _dbConnection.QueryAsync<TEntity>(
                    sql: $"SELECT * FROM {_tableName}");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to GetAll.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                ConnectionOpen();

                return await _dbConnection.QuerySingleAsync<TEntity>(
                    sql: $"SELECT * FROM {_tableName} WHERE Id = @Id",
                    param: new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to GetById.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                ConnectionOpen();

                return await GetByIdAsync(
                    id: _dbConnection.ExecuteScalarAsync<int>(
                        sql: GetUpdateQuery(),
                        param: entity).Result
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Failed to Update.", ex);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public void ConnectionClose()
        {
            if (_dbConnection.State != ConnectionState.Closed) _dbConnection.Close();
        }

        public void ConnectionOpen()
        {
            if (_dbConnection.State != ConnectionState.Open) _dbConnection.Open();
        }
    }
}
