using Coren.OnlinePortal.Web.Models.Dto.User;

namespace Coren.OnlinePortal.Web.Services.İnterfaces
{
    public interface IUserService
    {
        Task<T> LoginAsync<T>(ValidateUserRequest objToCreate);
        Task<T> RegisterAsync<T>(CreateUserRequest objToCreate);
    }
}
