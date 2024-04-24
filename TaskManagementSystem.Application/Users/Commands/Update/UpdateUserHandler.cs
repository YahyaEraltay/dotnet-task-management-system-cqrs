using MediatR;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUserService _userService;

        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var updatedUser = await _userService.Update(new UpdateUserRequestDTO
            {
                Id = request.Id,
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                DepartmentId = request.DepartmentId
            });

            var response = new UpdateUserResponse
            {
                Id = updatedUser.Id,
                UserName = updatedUser.UserName,
                UserEmail = updatedUser.UserEmail,
                DepartmentName = updatedUser.DepartmentName
            };

            return response;
        }
    }
}
