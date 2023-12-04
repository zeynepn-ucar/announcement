using Coren.OnlinePortal.Domain.Common;

namespace Coren.OnlinePortal.Domain.Entities
{
    public class AnnouncementLike : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
    }
}
