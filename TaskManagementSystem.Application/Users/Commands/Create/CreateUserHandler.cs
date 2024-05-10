using MediatR;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Users.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                UserPassword = request.UserPassword,    
                PhoneNumber = request.PhoneNumber,
                DepartmentId = request.DepartmentId,
                UserTitle = request.UserTitle
            };

            await _userRepository.Create(user);

            var response = new CreateUserResponse
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                PhoneNumber = user.PhoneNumber,
                DepartmentId = user.DepartmentId,
                UserTitle = user.UserTitle
            };

            return response;
        }
    }
}
