using Coren.OnlinePortal.Application.Exceptions.CustomError;
using Coren.OnlinePortal.Application.Models;
using Coren.OnlinePortal.Application.Models.Announcement;
using Coren.OnlinePortal.Application.Services.Announcement;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Coren.OnlinePortal.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        [HttpGet]
        public async Task<ActionResult<BaseServiceModel>> GetAllAnnouncement()
        {
            BaseServiceModel baseServiceModel;
            try
            {
                baseServiceModel = await _announcementService.GetAllAnnouncement();
                baseServiceModel.StatusCode = HttpStatusCode.OK;
                baseServiceModel.IsSuccess = true;
            }
            catch (NotFoundException ex)
            {
                baseServiceModel = new BaseServiceModel
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NoContent
                };
                baseServiceModel.ErrorMessages.Add(ex.Message);
            }
            return Ok(baseServiceModel);

        }

        [HttpPost]
        public async Task<ActionResult<BaseServiceModel>> CreateAnnouncement(CreateAnnouncementRequest request)
        {
            BaseServiceModel baseServiceModel;
            try
            {
                baseServiceModel = await _announcementService.CreateAnnouncement(request);
                baseServiceModel.StatusCode = HttpStatusCode.OK;
                baseServiceModel.IsSuccess = true;
            }
            catch (UnExpectedException ex)
            {
                baseServiceModel = new BaseServiceModel
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,

                };
                baseServiceModel.ErrorMessages.Add(ex.Message);
            }
            return baseServiceModel;
        }

        [HttpPut]
        public async Task<ActionResult<BaseServiceModel>> UpdateAnnouncement(UpdateAnnouncementRequest request)
        {
            try
            {
                await _announcementService.UpdateAnnouncement(request);
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (AnnouncementUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<BaseServiceModel>> DeleteAnnouncement(DeleteAnnouncementRequest request)
        {
            try
            {
                await _announcementService.DeleteAnnouncement(request);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (AnnouncementDeleteException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
