using Coren.OnlinePortal.Web.Models.Dto.Announcement;

namespace Coren.OnlinePortal.Web.Services.İnterfaces
{
    public interface IAnnouncementService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> CreateAsync<T>(CreateAnnouncementRequest request, string token);
        Task<T> UpdateAsync<T>(UpdateAnnouncementRequest request, string token);
        Task<T> DeleteAsync<T>(DeleteAnnouncementRequest request, string token);
    }
}
