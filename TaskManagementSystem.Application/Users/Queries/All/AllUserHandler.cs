using MediatR;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Users.Queries.All
{
    public class AllUserHandler : IRequestHandler<AllUserRequest, List<AllUserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public AllUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<AllUserResponse>> Handle(AllUserRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.All();

            var response = AllUserMapper.MapToResponse(users);

            return response;
        }
    }
}
