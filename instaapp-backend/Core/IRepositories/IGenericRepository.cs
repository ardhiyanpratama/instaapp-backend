namespace instaapp_backend.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(long id);

        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entities);

        Task<bool> UpdateAsync(T entity);

        Task<bool> UpdateRangeAsync(List<T> entities);

        Task<bool> DeleteAsync(long id);
    }
}
