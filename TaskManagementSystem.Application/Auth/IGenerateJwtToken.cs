using TaskManagementSystem.Application.Users.Commands.Login;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Auth
{
    public interface IGenerateJwtToken
    {
        public string GenerateToken(LoginUserResponse response);
    }
}
