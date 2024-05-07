using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DomainServices;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<UserResponseDTO> GetCurrentUser()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var password = await _userService.GetUserByEmail(email);

            var user = await _userRepository.Login(email, password);

            if (user != null)
            {
                return new UserResponseDTO
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
