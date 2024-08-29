using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>GetAsync(int id);
        Task<T>DeleteAsync(T entity);
        Task<T>UpdateAsync(T entity);
        Task<T>CreateAsync(T entity);
    }
}
