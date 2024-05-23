using BCrypt.Net;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Users.Commands.Create
{
    public static class CreateUserMapper
    {
        public static User MapToNewEntity(CreateUserRequest request)
        {
            return new User
            {
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(request.UserPassword), 
                PhoneNumber = request.PhoneNumber,
                DepartmentId = request.DepartmentId,
                UserTitle = request.UserTitle
            };
        }

        public static CreateUserResponse MapToResponse(User user)
        {
            return new CreateUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                PhoneNumber = user.PhoneNumber,
                DepartmentId = user.DepartmentId,
                UserTitle = user.UserTitle
            };
        }
    }
}
