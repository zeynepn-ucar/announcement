using Coren.OnlinePortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Coren.OnlinePortal.Persistence.Context
{
    public class OnlinePortalDbContext : DbContext
    {
        public OnlinePortalDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementComment> AnnouncementComments { get; set; }
        public DbSet<AnnouncementLike> AnnouncementLikes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
