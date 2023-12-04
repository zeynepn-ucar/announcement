using Coren.OnlinePortal.Web.Services;
using Coren.OnlinePortal.Web.Services.İnterfaces;
using System.Reflection;

namespace Coren.OnlinePortal.Web
{
    public static class Registration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IAnnouncementService, AnnouncementService>();
            services.AddHttpClient<IUserService, UserService>();

            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IUserService, UserService>();
        }
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(cfg => cfg.AddMaps(assembly));

            return services;
        }
    }
}
