using Coren.OnlinePortal.Domain.Common;

namespace Coren.OnlinePortal.Application.Abstracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntity, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntity, new();
        Task<int> SaveAsync();
        int Save();
    }
}
