using AutoMapper;

namespace Coren.OnlinePortal.Web.Models.Dto.User
{
    [AutoMap(typeof(UserDto), ReverseMap = true)]
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
