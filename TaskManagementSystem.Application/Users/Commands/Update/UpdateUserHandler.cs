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
            var updatedUser = await _userRepository.GetById(request.Id);

            if (currentUser.Id == request.Id)
            {
                updatedUser.Id = request.Id;
                updatedUser.UserName = request.UserName;
                updatedUser.UserEmail = request.UserEmail;
                updatedUser.UserTitle = request.UserTitle;
                updatedUser.UserPassword = request.UserPassword;
                updatedUser.PhoneNumber = request.PhoneNumber;
                updatedUser.DepartmentId = request.DepartmentId;

                var response = new UpdateUserResponse
                {
                    Id = updatedUser.Id,
                    UserName = updatedUser.UserName,
                    UserEmail = updatedUser.UserEmail,
                    UserTitle = updatedUser.UserTitle,
                    PhoneNumber = updatedUser.PhoneNumber,
                    DepartmentName = updatedUser.Department.DepartmentName
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
