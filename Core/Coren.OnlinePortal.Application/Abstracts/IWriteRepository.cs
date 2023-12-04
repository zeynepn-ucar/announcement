using Coren.OnlinePortal.Domain.Common;

namespace Coren.OnlinePortal.Application.Abstracts
{
    public interface IWriteRepository<T> where T : class, IEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
