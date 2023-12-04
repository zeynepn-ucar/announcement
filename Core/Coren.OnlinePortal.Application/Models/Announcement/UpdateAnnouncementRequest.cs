using AutoMapper;

namespace Coren.OnlinePortal.Application.Models.Announcement
{
    [AutoMap(typeof(Domain.Entities.Announcement), ReverseMap = true)]
    public class UpdateAnnouncementRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool ShowHomePage { get; set; }
        public string Content { get; set; }
    }
}
