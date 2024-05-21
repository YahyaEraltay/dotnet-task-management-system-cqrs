using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Users.Commands.Update
{
    public class UpdateUserMapper
    {
        public static User MapToEntity(UpdateUserRequest request, User user)
        {
            user.Id = request.Id;
            user.UserName = request.UserName;
            user.UserEmail = request.UserEmail;
            user.UserTitle = request.UserTitle;
            user.UserPassword = request.UserPassword;
            user.PhoneNumber = request.PhoneNumber;
            user.DepartmentId = request.DepartmentId;

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
