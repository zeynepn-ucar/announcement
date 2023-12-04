using AutoMapper;
using Coren.OnlinePortal.Application.Abstracts;
using Coren.OnlinePortal.Application.Exceptions.CustomError;
using Coren.OnlinePortal.Application.Models;
using Coren.OnlinePortal.Application.Models.User;
using Coren.OnlinePortal.Application.Services.Security;

namespace Coren.OnlinePortal.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ISecurityService _securityService;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ISecurityService securityService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _securityService = securityService;

        }

        public async Task<BaseServiceModel> CreateUser(CreateUserRequest request)
        {
            BaseServiceModel baseServiceModel = new();
            var response = new CreateUserResponse();
            var currentUser = await _unitOfWork.GetReadRepository<Domain.Entities.User>().GetAsync(user => user.Email == request.Email);

            if (currentUser == null)
            {
                request.Password = _securityService.ComputeHash(request.Password, 3);
                var user = _mapper.Map<Domain.Entities.User>(request);

                await _unitOfWork.GetWriteRepository<Domain.Entities.User>().AddAsync(user);
                await _unitOfWork.SaveAsync();

                response = _mapper.Map<CreateUserResponse>(user);
                baseServiceModel.Result = response;
            }
            else
            {
                throw new UserAlreadyExistsException("User with the same email already exists.");
            }
            return baseServiceModel;
        }

        public async Task<ValidateUserResponse> ValidateUser(ValidateUserRequest request)
        {
            var result = new ValidateUserResponse();
            request.Password = _securityService.ComputeHash(request.Password, 3);
            var currentUser = await _unitOfWork.GetReadRepository<Domain.Entities.User>().GetAsync(s => s.Email == request.Email && s.Password == request.Password);
            if (currentUser != null)
                result = _mapper.Map<ValidateUserResponse>(currentUser);

            else throw new UserNotFoundException("Username or password is incorrect");
            return result;
        }

    }
}
