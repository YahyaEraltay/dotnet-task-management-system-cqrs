﻿using TaskManagementSystem.Application.Users.Commands.Login;
using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.LoginUserDTOs;

namespace TaskManagementSystem.Infrastructure.Services
{
    public interface IGenerateJwtToken
    {
        public string GenerateToken(LoginUserResponse response);
    }
}
