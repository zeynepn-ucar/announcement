using Coren.OnlinePortal.Domain.Common;

namespace Coren.OnlinePortal.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<AnnouncementComment> AnnouncementComments { get; set; }
        public List<AnnouncementLike> AnnouncementLikes { get; set; }
    }
}
