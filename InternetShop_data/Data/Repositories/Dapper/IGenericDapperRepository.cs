namespace InternetShop_data.Data.Repositories
{
    public interface IGenericDapperRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        void ConnectionClose();
        void ConnectionOpen();
    }
}
