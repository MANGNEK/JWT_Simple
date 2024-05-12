using JWT_Simple.Context;
using JWT_Simple.Interface;
using Microsoft.EntityFrameworkCore;

namespace JWT_Simple.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly JwtContext _jwtContext;
    public GenericRepository(JwtContext jwtContext)
    {
        _jwtContext = jwtContext;
    }
    public async Task CreateAsync(T entity)
    {
        await _jwtContext.Set<T>().AddAsync(entity);
    }

    public void DeleteAsync(T entity)
    {
         _jwtContext.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
       return await _jwtContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(int id)
    {
        return await _jwtContext.Set<T>().FindAsync(id);
    }

    public void UpdateAsync(T entity)
    {
        _jwtContext.Set<T>().Update(entity);
    }
}
