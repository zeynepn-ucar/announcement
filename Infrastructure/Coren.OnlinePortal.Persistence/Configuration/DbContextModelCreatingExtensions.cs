using Coren.OnlinePortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coren.OnlinePortal.Persistence.Configuration
{
    public static class DbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<Announcement>(b =>
            {
                b.HasMany(f => f.AnnouncementComments).WithOne(f => f.Announcement).HasForeignKey(f => f.AnnouncementId);
                b.HasMany(f => f.AnnouncementLikes).WithOne(f => f.Announcement).HasForeignKey(f => f.AnnouncementId);
            });
            builder.Entity<AnnouncementComment>(b =>
            {

            });
            builder.Entity<AnnouncementLike>(b =>
            {
            });
            builder.Entity<User>(b =>
            {
                b.HasMany(f => f.AnnouncementComments).WithOne(f => f.User).HasForeignKey(f => f.AnnouncementId);
                b.HasMany(f => f.AnnouncementLikes).WithOne(f => f.User).HasForeignKey(f => f.AnnouncementId);
            });
        }
    }
}
