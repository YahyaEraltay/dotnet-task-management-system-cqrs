using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateUserHandler(IUserRepository userRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUserService.GetCurrentUser();
            var user = await _userRepository.GetById(request.Id);

            if (currentUser.Id == request.Id)
            {
                user = UpdateUserMapper.MapToEntity(request, user);

                await _userRepository.Update(user);

                var response = UpdateUserMapper.MapToResponse(user);

                return response;
            }
            else
            {
                throw new Exception("You can only update user that you have created yourself");
            }
        }
    }
}
