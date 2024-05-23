using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskManagementSystem.Domain.Entites;
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
            var user = await _userRepository.GetUserByEmail(email);
            
            if (user != null)
            {
                return new ResponseModel
                {
                    Id = user.Id,
                    DepartmentId = user.DepartmentId,
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
