using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Users.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public DeleteUserHandler(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUserService.GetCurrentUser();
            var user = await _userService.GetById(request.Id);

            var response = new DeleteUserResponse();

            if (currentUser.Id == request.Id)
            {
                await _userService.Delete(new Infrastructure.DTOs.UserDTOs.DeleteUserDTOs.RequestModel
                {
                    Id = user.Id
                });

                response.IsDeleted = true;
                response.Message = "User deleted";

                return response;
            }
            else
            {
                throw new Exception("You can only delete user that you have created yourself");
            }
        }
    }
}
