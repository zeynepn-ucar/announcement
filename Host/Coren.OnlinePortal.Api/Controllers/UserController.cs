using Coren.OnlinePortal.Application.Exceptions.CustomError;
using Coren.OnlinePortal.Application.Models;
using Coren.OnlinePortal.Application.Models.User;
using Coren.OnlinePortal.Application.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Coren.OnlinePortal.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseServiceModel>> CreateUser(CreateUserRequest request)
        {
            BaseServiceModel baseServiceModel;
            try
            {
                baseServiceModel = await _userService.CreateUser(request);
                baseServiceModel.StatusCode = HttpStatusCode.OK;
                baseServiceModel.IsSuccess = true;
            }
            catch (UserAlreadyExistsException ex)
            {
                baseServiceModel = new BaseServiceModel
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.Conflict
                };
                baseServiceModel.ErrorMessages.Add(ex.Message);
            }
            return Ok(baseServiceModel);
        }

        [HttpPost]
        public async Task<ActionResult<BaseServiceModel>> Login(ValidateUserRequest request)
        {
            BaseServiceModel baseServiceModel = new();
            try
            {
                baseServiceModel.Result = await _userService.ValidateUser(request);
                baseServiceModel.StatusCode = HttpStatusCode.OK;
                baseServiceModel.IsSuccess = true;
            }
            catch (UserAlreadyExistsException ex)
            {
                baseServiceModel.IsSuccess = false;
                baseServiceModel.StatusCode = HttpStatusCode.Unauthorized;
                baseServiceModel.ErrorMessages.Add(ex.Message);
            }
            return Ok(baseServiceModel);
        }
    }
}
