using Coren.OnlinePortal.Web.Models;
using Coren.OnlinePortal.Web.Models.Dto.User;
using Coren.OnlinePortal.Web.Services.İnterfaces;

namespace Coren.OnlinePortal.Web.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string userApiUrl;

        public UserService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            userApiUrl = configuration.GetValue<string>("ServiceUrls:ApiUrl") + "api/User";

        }

        public Task<T> LoginAsync<T>(ValidateUserRequest request)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = request,
                Url = userApiUrl + "/Login"
            });
        }

        public Task<T> RegisterAsync<T>(CreateUserRequest request)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = request,
                Url = userApiUrl + "/CreateUser"
            });
        }

        public Task<T> RegisterAsync<T>(ValidateUserRequest objToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
