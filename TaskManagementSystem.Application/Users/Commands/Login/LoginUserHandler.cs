using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Users.Commands.Login
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Login(request.UserEmail, request.UserPassword);

            return new LoginUserResponse //Aslında burası çalışmıyor token dönüyor.
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail
            };
        }
    }
}
