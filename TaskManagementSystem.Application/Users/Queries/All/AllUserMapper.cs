using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Users.Queries.All
{
    public class AllUserMapper
    {
        public static List<AllUserResponse> MapToResponse(List<User> users)
        {
            return users?.Select(user => new AllUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                DepartmentName = user.Department?.DepartmentName
            }).ToList();
        }
    }
}
