using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;

namespace TaskManagementSystem.Application.Users.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new CreateUserRequestDTO
            {
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                UserPassword = request.UserPassword,    
                PhoneNumber = request.PhoneNumber,
                DepartmentId = request.DepartmentId,
                UserTitle = request.UserTitle
            };

            await _userService.Create(user);

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
