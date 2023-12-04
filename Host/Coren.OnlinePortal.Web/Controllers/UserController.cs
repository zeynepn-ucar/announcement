using Coren.OnlinePortal.Web.Models;
using Coren.OnlinePortal.Web.Models.Dto.User;
using Coren.OnlinePortal.Web.Services.İnterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Coren.OnlinePortal.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Login(ValidateUserRequest request)
        {
            var response = await _userService.LoginAsync<ApiResponse>(request);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("IndexAnnouncementList", "Announcement");
            }

            ViewData["ErrorMessage"] = response?.ErrorMessages?.FirstOrDefault();
            //todo :_logger.LogError($"Login failed for user '{request.Email}': {response?.ErrorMessages?.FirstOrDefault()}");
            return View(request);
        }
        
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "User");
        }
        //todo:forgetpassword
    }
}
