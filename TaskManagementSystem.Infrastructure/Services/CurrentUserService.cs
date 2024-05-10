﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.CurrentUserDTOs;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<ResponseModel> GetCurrentUser()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var password = await _userRepository.GetUserByEmail(email);

            var user = await _userRepository.Login(email, password);

            if (user != null)
            {
                return new ResponseModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    PhoneNumber = user.PhoneNumber,
                    DepartmentName = user.Department.DepartmentName,
                    UserTitle = user.UserTitle
                };
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
