using AutoMapper;

namespace Coren.OnlinePortal.Web.Models.Dto.Announcement
{
    [AutoMap(typeof(AnnouncementDto), ReverseMap = true)]
    public class UpdateAnnouncementRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool ShowHomePage { get; set; }
        public string Content { get; set; }
    }
}
