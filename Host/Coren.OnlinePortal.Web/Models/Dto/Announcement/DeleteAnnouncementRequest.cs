using AutoMapper;

namespace Coren.OnlinePortal.Web.Models.Dto.Announcement
{
    [AutoMap(typeof(AnnouncementDto), ReverseMap = true)]
    public class DeleteAnnouncementRequest
    {
        public int Id { get; set; }
    }
}
