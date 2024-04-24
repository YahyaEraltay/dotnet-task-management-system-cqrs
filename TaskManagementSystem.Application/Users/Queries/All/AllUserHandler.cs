using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Users.Queries.All
{
    public class AllUserHandler : IRequestHandler<AllUserRequest, List<AllUserResponse>>
    {
        private readonly IUserService _userService;

        public AllUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<AllUserResponse>> Handle(AllUserRequest request, CancellationToken cancellationToken)
        {
            var users = await _userService.All();
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
                        DepartmentName = user.DepartmentName
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
