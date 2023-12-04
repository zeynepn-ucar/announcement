using Coren.OnlinePortal.Web.Models;

namespace Coren.OnlinePortal.Web.Services.İnterfaces
{
    public interface IBaseService
    {
        ApiResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
