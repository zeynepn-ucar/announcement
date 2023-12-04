using AutoMapper;

namespace Coren.OnlinePortal.Application.Models.Announcement
{
    [AutoMap(typeof(Domain.Entities.Announcement), ReverseMap = true)]
    public class DeleteAnnouncementRequest
    {
        public int Id { get; set; }
    }
}
