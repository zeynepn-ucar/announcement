using Coren.OnlinePortal.Application.Models;
using Coren.OnlinePortal.Application.Models.User;

namespace Coren.OnlinePortal.Application.Services.User
{
    public interface IUserService
    {
        Task<BaseServiceModel> CreateUser(CreateUserRequest request);
        Task<ValidateUserResponse> ValidateUser(ValidateUserRequest request);
    }
}
