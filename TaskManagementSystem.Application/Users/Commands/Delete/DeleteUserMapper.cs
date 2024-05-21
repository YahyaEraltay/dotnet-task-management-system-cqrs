using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Users.Commands.Delete
{
    public class DeleteUserMapper
    {
        public static User MapToEntity (User user)
        {
            return new User
            {
                Id = user.Id
            };
        }

        public static DeleteUserResponse MapToResponse(bool isDeleted, string message)
        {
            return new DeleteUserResponse
            {
                IsDeleted = isDeleted,
                Message = message
            };
        }
    }
}
