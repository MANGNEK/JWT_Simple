namespace JWT_Simple.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

    }
}
