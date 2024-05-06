using MediatR;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public UpdateUserHandler(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUserService.GetCurrentUser();

            if (currentUser.Id == request.Id)
            {
                var updatedUser = await _userService.Update(new UpdateUserRequestDTO
                {
                    Id = request.Id,
                    UserName = request.UserName,
                    UserEmail = request.UserEmail,
                    UserTitle = request.UserTitle,
                    UserPassword = request.UserPassword,
                    PhoneNumber = request.PhoneNumber,
                    DepartmentId = request.DepartmentId
                });

                var response = new UpdateUserResponse
                {
                    Id = updatedUser.Id,
                    UserName = updatedUser.UserName,
                    UserEmail = updatedUser.UserEmail,
                    UserTitle = updatedUser.UserTitle,
                    PhoneNumber = updatedUser.PhoneNumber,  
                    DepartmentName = updatedUser.DepartmentName
                };

                return response;
            }
            else
            {
                throw new Exception("You can only update user that you have created yourself");
            }
        }
    }
}
