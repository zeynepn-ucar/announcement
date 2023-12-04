using Coren.OnlinePortal.Application.Models;
using Coren.OnlinePortal.Application.Models.Announcement;

namespace Coren.OnlinePortal.Application.Services.Announcement
{
    public interface IAnnouncementService
    {
        Task<BaseServiceModel> GetAllAnnouncement();
        Task<BaseServiceModel> CreateAnnouncement(CreateAnnouncementRequest request);
        Task UpdateAnnouncement(UpdateAnnouncementRequest request);
        Task DeleteAnnouncement(DeleteAnnouncementRequest request);
    }
}
