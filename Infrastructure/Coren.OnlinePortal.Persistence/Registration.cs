using Coren.OnlinePortal.Application.Abstracts;
using Coren.OnlinePortal.Persistence.Context;
using Coren.OnlinePortal.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coren.OnlinePortal.Persistence
{
    public static class Registration 
    {
        public static void CreateDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnlinePortalDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
