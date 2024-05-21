using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Users.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteUserHandler(IUserRepository userRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUserService.GetCurrentUser();
            var user = await _userRepository.GetById(request.Id);

            if (currentUser.Id == request.Id)
            {
                var userToDelete = DeleteUserMapper.MapToEntity(user);

                await _userRepository.Delete(userToDelete);

                var response = DeleteUserMapper.MapToResponse(true, "User deleted");

                return response;
            }
            else
            {
                throw new Exception("You can only delete user that you have created yourself");
            }
        }
    }
}
