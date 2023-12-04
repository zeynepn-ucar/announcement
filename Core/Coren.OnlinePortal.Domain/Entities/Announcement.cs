using Coren.OnlinePortal.Domain.Common;

namespace Coren.OnlinePortal.Domain.Entities
{
    public class Announcement : EntityBase
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public bool ShowHomePage { get; set; }
        public string Content { get; set; }
        public List<AnnouncementComment> AnnouncementComments { get; set; }
        public List<AnnouncementLike> AnnouncementLikes { get; set; }
    }
}
