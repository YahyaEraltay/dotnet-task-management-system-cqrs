using MediatR;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Application.Users.Queries.Detail
{
    public class DetailUserHandler : IRequestHandler<DetailUserRequest, DetailUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public DetailUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DetailUserResponse> Handle(DetailUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            var response = new DetailUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                DepartmentName = user.Department.DepartmentName
            };

            return response;
        }
    }
}
