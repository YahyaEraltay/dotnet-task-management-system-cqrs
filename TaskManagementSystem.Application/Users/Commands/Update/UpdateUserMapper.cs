using BCrypt.Net;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Users.Commands.Update
{
    public static class UpdateUserMapper
    {
        public static User MapToEntity(UpdateUserRequest request, User user)
        {
            user.Id = request.Id;
            user.UserName = request.UserName;
            user.UserEmail = request.UserEmail;
            user.UserTitle = request.UserTitle;
            user.PhoneNumber = request.PhoneNumber;
            user.DepartmentId = request.DepartmentId;

            if (!string.IsNullOrEmpty(request.UserPassword))
            {
                user.UserPassword = BCrypt.Net.BCrypt.HashPassword(request.UserPassword);
            }
            return user;
        }

        public static UpdateUserResponse MapToResponse(User user)
        {
            return new UpdateUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                UserTitle = user.UserTitle,
                PhoneNumber = user.PhoneNumber,
                DepartmentName = user.Department.DepartmentName
            };
        }
    }
}
