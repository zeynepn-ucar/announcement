using Coren.OnlinePortal.Web.Models;
using Coren.OnlinePortal.Web.Models.Dto.Announcement;
using Coren.OnlinePortal.Web.Services.İnterfaces;

namespace Coren.OnlinePortal.Web.Services
{
    public class AnnouncementService : BaseService, IAnnouncementService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string announcementApiUrl;
        public AnnouncementService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            announcementApiUrl = configuration.GetValue<string>("ServiceUrls:ApiUrl") + "api/Announcement";
        }

        public Task<T> CreateAsync<T>(CreateAnnouncementRequest request, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = request,
                Url = announcementApiUrl,
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(DeleteAnnouncementRequest request, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Data = request,
                Url = announcementApiUrl,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            var rq= SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = announcementApiUrl + "/GetAllAnnouncement",
                Token = token
            });
            return rq;
        }
        public Task<T> UpdateAsync<T>(UpdateAnnouncementRequest request, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = request,
                Url = announcementApiUrl,
                Token = token
            });
        }
    }
}
