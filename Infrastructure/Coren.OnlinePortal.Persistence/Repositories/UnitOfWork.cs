using Coren.OnlinePortal.Application.Abstracts;
using Coren.OnlinePortal.Persistence.Context;

namespace Coren.OnlinePortal.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlinePortalDbContext dbContext;
        public UnitOfWork(OnlinePortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
        public int Save() => dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }
}
