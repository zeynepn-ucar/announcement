using AutoMapper;

namespace Coren.OnlinePortal.Application.Models.User
{
    [AutoMap(typeof(Domain.Entities.User), ReverseMap = true)]
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
