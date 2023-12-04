using AutoMapper;
using Coren.OnlinePortal.Web.Models;
using Coren.OnlinePortal.Web.Models.Dto.Announcement;
using Coren.OnlinePortal.Web.Models.ViewModels;
using Coren.OnlinePortal.Web.Services.İnterfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Coren.OnlinePortal.Web.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
        }
        public async Task<IActionResult> IndexAnnouncementList()
        {
            List<AnnouncementDto> announcements;
            AnnouncementListViewModel model;

            var response = await _announcementService.GetAllAsync<ApiResponse>("JWTToken");
            if (response != null && response.IsSuccess)
            {
                announcements = JsonConvert.DeserializeObject<List<AnnouncementDto>>(response.Result.ToString());
                model = new AnnouncementListViewModel
                {
                    Announcements = announcements
                    // comments and likes
                };
                return View(model);
            }

            announcements = new List<AnnouncementDto>();
            model = new AnnouncementListViewModel
            {
                Announcements = announcements
            };
            ViewData["ErrorMessage"] = response?.ErrorMessages?.FirstOrDefault();
            return View(model);

        }
    }
}
