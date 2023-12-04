using Coren.OnlinePortal.Application.Exceptions;
using Coren.OnlinePortal.Application.Services.Announcement;
using Coren.OnlinePortal.Application.Services.Comment;
using Coren.OnlinePortal.Application.Services.Security;
using Coren.OnlinePortal.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Coren.OnlinePortal.Application
{
    public static class Registration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ICommentService, CommentService>();
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(cfg => cfg.AddMaps(assembly));

            return services;
        }
    }
}
