using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public CurrentUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<UserResponseDTO> GetCurrentUser()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;

            var user = await _userRepository.Login(email);

            if (user != null)
            {
                return new UserResponseDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    DepartmentName = user.Department.DepartmentName
                };
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
