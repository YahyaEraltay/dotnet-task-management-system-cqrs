using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Users.Queries.Detail
{
    public class DetailUserMapper
    {
        public static DetailUserResponse MapToResponse(User user)
        {
            return new DetailUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                DepartmentName = user.Department.DepartmentName
            };
        }
    }
}
