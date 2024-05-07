using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;

namespace TaskManagementSystem.Application.Users.Queries.Detail
{
    public class DetailUserHandler : IRequestHandler<DetailUserRequest, DetailUserResponse>
    {
        private readonly IUserService _userService;

        public DetailUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<DetailUserResponse> Handle(DetailUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(request.Id);

            var response = new DetailUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                DepartmentName = user.DepartmentName
            };

            return response;
        }
    }
}
