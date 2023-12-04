using Coren.OnlinePortal.Application.Abstracts;
using Coren.OnlinePortal.Application.Models.Announcement;
using AutoMapper;
using Coren.OnlinePortal.Application.Models;
using Coren.OnlinePortal.Application.Exceptions.CustomError;

namespace Coren.OnlinePortal.Application.Services.Announcement
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AnnouncementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseServiceModel> GetAllAnnouncement()
        {
            BaseServiceModel baseServiceModel = new();
            var announcementList = await _unitOfWork.GetReadRepository<Domain.Entities.Announcement>().GetAllAsync();
            var result = _mapper.Map<List<GetAnnouncementListResponse>>(announcementList);
            if (result != null)
            {
                baseServiceModel.Result = result;
                return baseServiceModel;
            }
            else
            {
                throw new NotFoundException("Announcement not found");
            }
        }
        public async Task<BaseServiceModel> CreateAnnouncement(CreateAnnouncementRequest request)
        {
            BaseServiceModel baseServiceModel = new();
            var announcement = _mapper.Map<Domain.Entities.Announcement>(request);
            var response = await _unitOfWork.GetWriteRepository<Domain.Entities.Announcement>().AddAsync(announcement);
            await _unitOfWork.SaveAsync();
            var result = _mapper.Map<CreateAnnouncementResponse>(response);

            if (result != null)
            {
                baseServiceModel.Result = result;
                return baseServiceModel;
            }
            else
            {
                throw new UnExpectedException("An unexpected error occurred");
            }
        }
        public async Task UpdateAnnouncement(UpdateAnnouncementRequest request)
        {
            try
            {
                var currentAnnouncement = await _unitOfWork.GetReadRepository<Domain.Entities.Announcement>().GetAsync(s => s.Id == request.Id);
                var result = _mapper.Map<Domain.Entities.Announcement>(currentAnnouncement);

                await _unitOfWork.GetWriteRepository<Domain.Entities.Announcement>().UpdateAsync(result);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw new AnnouncementUpdateException("Announcement update failed.");
            }
        }
        public async Task DeleteAnnouncement(DeleteAnnouncementRequest request)
        {
            try
            {
                var announcement = await _unitOfWork.GetReadRepository<Domain.Entities.Announcement>().GetAsync(s => s.Id == request.Id);
                var result = _mapper.Map<Domain.Entities.Announcement>(announcement);

                await _unitOfWork.GetWriteRepository<Domain.Entities.Announcement>().DeleteAsync(result);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw new AnnouncementDeleteException("Announcement deletion failed.");
            }
        }
    }
}
