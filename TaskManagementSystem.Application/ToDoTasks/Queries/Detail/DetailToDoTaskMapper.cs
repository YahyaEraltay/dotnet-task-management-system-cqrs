using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.Detail
{
    public class DetailToDoTaskMapper
    {
        public static DetailToDoTaskResponse MapToResponse(ToDoTask task)
        {
            return new DetailToDoTaskResponse
            {
                Id = task.Id,
                ToDoTaskName = task.ToDoTaskName,
                AssignedDepartmentName = task.Department.DepartmentName,
                CreatorUserName = task.CreatorUser.UserName,
                AssignedUserName = task.AssignedUser.UserName,
                AssignedUserEmail = task.AssignedUser.UserEmail,
                Status = task.Status,
            };
        }
    }
}
