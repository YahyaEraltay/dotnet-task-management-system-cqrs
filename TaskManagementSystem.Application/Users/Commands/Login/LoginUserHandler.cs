﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserRequestModel;

namespace TaskManagementSystem.Application.Users.Commands.Login
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUserService _userService;

        public LoginUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.Login(new LoginUserRequestDTO
            {
                UserEmail = request.UserEmail,
                UserPassword = request.UserPassword
            });

            if (user != null)
            {
                return new LoginUserResponse
                {
                    UserName = user.UserName,
                    UserEmail = user.UserEmail
                };
            }
            else
            {
                throw new Exception("Invalid email adress or password");
            }
        }
    }
}
