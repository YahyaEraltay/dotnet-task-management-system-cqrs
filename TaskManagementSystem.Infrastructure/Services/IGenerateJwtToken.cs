using TaskManagementSystem.Domain.Entites;
using TaskManagementSystem.Infrastructure.DTOs.UserDTOs.UserResponseModel;

namespace TaskManagementSystem.Infrastructure.Services
{
    public interface IGenerateJwtToken
    {
        public string GenerateToken(LoginUserResponseDTO response);
    }
}
