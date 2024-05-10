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
            var response = new List<AllUserResponse>();

            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    response.Add(new AllUserResponse
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        UserEmail = user.UserEmail,
                        DepartmentName = user.Department.DepartmentName
                    });
                }
            }
            else
            {
                throw new Exception("There is no user");
            }

            return response;
        }
    }
}
