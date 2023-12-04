using Coren.OnlinePortal.Application.Abstracts;
using Coren.OnlinePortal.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Coren.OnlinePortal.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<T> AddAsync(T entity)
        {
            await Task.Run(() => Table.AddAsync(entity));
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

    }
}
