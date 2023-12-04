using Coren.OnlinePortal.Domain.Common;

namespace Coren.OnlinePortal.Domain.Entities
{
    public class AnnouncementComment : EntityBase
    {
        public int AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }
    }
}
